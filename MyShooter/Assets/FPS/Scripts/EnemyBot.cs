using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace FPS
{ 
    public class EnemyBot : MonoBehaviour, IDamageable
    {
        public Transform EyesTransform;

        private float searchDistance;
        private float rangeAttackDistance;
        private float meleeAttackDistance;

        private float maxRandomRadius;
        private bool useRandomWP;

        private Waypoint[] waypoints;
        private int currentWP;
        private float currentWPTimeout;

        private NavMeshAgent agent;
        private Vector3 randomPos;
        private Transform targetTransform;

        [SerializeField]
        private BaseWeapon rangeWeapon;
        [SerializeField]
        private BaseWeapon meleeWeapon;


        public void Initialize(BotSpawnParams spawnParams)
        {
            searchDistance = Mathf.Max(2, spawnParams.SearchDistance);
            rangeAttackDistance = Mathf.Max(2, spawnParams.RangeAttackDistance);
            meleeAttackDistance = Mathf.Max(2, spawnParams.MeleeAttackDistance);
            maxRandomRadius = Mathf.Max(2, spawnParams.MaxRandomRadius);

            waypoints = spawnParams.Waypoints;
            useRandomWP = waypoints.Length <= 1;

            agent = GetComponent<NavMeshAgent>();

            rangeWeapon.IsVisible = true;

            Main.Instance.EnemyBotsController.AddBot(this);
        }

        public void SetTarget(Transform taget)
        {
            targetTransform = taget;
        }

        private void Update()
        {
            if(!targetTransform && Main.Instance.PlayerModel)
            {
                targetTransform = Main.Instance.PlayerModel.transform;
                return;
            }

            if (CurrentHealth <= 0) return;

            var isTargetSeen = false;

            if(targetTransform)
            {
                var dist = Vector3.Distance(transform.position, targetTransform.position);

                if (dist < searchDistance)
                {
                    isTargetSeen = CheckTarget();
                    if (isTargetSeen) agent.SetDestination(targetTransform.position);
                    //if(dist > attackDistance * 0.5f) agent.SetDestination(targetTransform.position);
                }

                if (dist < meleeAttackDistance && isTargetSeen)
                {
                    if(!meleeWeapon.IsVisible)
                    { 
                        rangeWeapon.IsVisible = false;
                        meleeWeapon.IsVisible = true;
                    }
                    meleeWeapon.Fire();
                    return;
                }
                if (dist < rangeAttackDistance && isTargetSeen)
                {
                    if (!rangeWeapon.IsVisible)
                    {
                        rangeWeapon.IsVisible = true;
                        meleeWeapon.IsVisible = false;
                    }
                    rangeWeapon.Fire();
                    return;
                }
            }

            if (isTargetSeen) return;

            if(useRandomWP)
            {
                agent.SetDestination(randomPos);
                if (!agent.hasPath || agent.remainingDistance > maxRandomRadius * 2) randomPos = GenerateWaypoint();
            }
            else
            {
                agent.SetDestination(waypoints[currentWP].transform.position);

                if(!agent.hasPath)
                {
                    currentWPTimeout += Time.deltaTime;
                    if(currentWPTimeout >= waypoints[currentWP].WaitTime)
                    {
                        currentWPTimeout = 0;
                        currentWP++;
                        if (currentWP >= waypoints.Length) currentWP = 0;
                    }
                }
            }
        }

        private bool CheckTarget()
        {
            RaycastHit hit;
            if (Physics.Linecast(EyesTransform.position, targetTransform.position, out hit) && hit.transform == targetTransform)
            {
                Debug.DrawLine(EyesTransform.position, targetTransform.position, Color.red);
                return true;
            }
            else if (Physics.Linecast(EyesTransform.position, targetTransform.position + Vector3.up * 0.5f, out hit) && hit.transform == targetTransform)
            {
                Debug.DrawLine(EyesTransform.position, targetTransform.position, Color.red);
                return true;
            }
            else if (Physics.Linecast(EyesTransform.position, targetTransform.position - Vector3.up * 0.5f, out hit) && hit.transform == targetTransform)
            {
                Debug.DrawLine(EyesTransform.position, targetTransform.position, Color.red);
                return true;
            }

            Debug.DrawLine(EyesTransform.position, targetTransform.position, Color.green);
            return false;
        }

        private Vector3 GenerateWaypoint()
        {
            Vector3 result = maxRandomRadius * Random.insideUnitSphere;

            if (NavMesh.SamplePosition(transform.position + result, out NavMeshHit hit, maxRandomRadius * 1.5f, NavMesh.AllAreas))
                return hit.position;

            return transform.position;
        }

        #region IDamageable implementation
        [SerializeField]
        private float currentHealth = 100f;

        public float CurrentHealth
        {
            get { return currentHealth; }
            set { currentHealth = value; }
        }

        public void ApplyDamage(float damage, Vector3 damageDirection)
        {
            if (CurrentHealth <= 0) return;
            CurrentHealth -= damage;
            if (CurrentHealth <= 0) Death();
        }

        private void Death()
        {
            foreach (var c in GetComponentsInChildren<Transform>())
            {
                c.SetParent(null);
                Destroy(c.gameObject, Random.Range(2f, 4f));

                var col = c.GetComponent<Collider>();
                if (col) col.enabled = true;

                var rb = c.gameObject.AddComponent<Rigidbody>();
                rb.mass = 5;
                rb.AddForce(Vector3.up * Random.Range(10f, 30f), ForceMode.Impulse);
            }

            Main.Instance.EnemyBotsController.RemoveBot(this);
        }
        #endregion IDamageable implementation

        [Serializable]
        public class BotSpawnParams
        {
            public float SearchDistance;
            public float RangeAttackDistance;
            public float MeleeAttackDistance;
            public float MaxRandomRadius;
            public Waypoint[] Waypoints;
        }
    }
}