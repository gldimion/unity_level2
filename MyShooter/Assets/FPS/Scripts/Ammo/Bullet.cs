using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class Bullet : BaseAmmo
    {
        [SerializeField]
        protected float selfDestroyTimeAfterHit = 0.3f;

        [SerializeField]
        protected float damageChangeOverTime = 0f;
        private float damageMultiplyer;

        private float speed;
        private bool isHitted;
        protected float hitDelta = 0f;

        [SerializeField]
        private string poolID;
        public override string PoolID => poolID;

        [SerializeField]
        private int objectsCount = 10;
        public override int ObjectsCount => objectsCount;

        public override void Initialize(float force, Transform firepoint)
        {
            CancelInvoke();

            isHitted = false;
            damageMultiplyer = 1f;
            Transform.position = firepoint.position;
            Transform.rotation = firepoint.rotation;
            speed = force;

            gameObject.SetActive(true);
        }

        protected virtual void BulletHittedAction()
        {
        }

        public void FixedUpdate()
        {
            if (isHitted) return;

            Vector3 finalPos = Transform.position + Transform.forward * speed * Time.fixedDeltaTime;

            if (Physics.Linecast(Transform.position, finalPos, out RaycastHit hit))
            {
                isHitted = true;
                Transform.position = hit.point - Transform.forward * hitDelta;

                IDamageable damageable = hit.collider.GetComponent<IDamageable>();
                if (damageable != null) damageable.ApplyDamage(damage * damageMultiplyer, Transform.forward);

                BulletHittedAction();

                //Destroy(GameObject, selfDestroyTimeAfterHit);
                Invoke("Disable", selfDestroyTimeAfterHit);
            }
            else
            {
                Transform.position = finalPos;
                damageMultiplyer += damageChangeOverTime;
            }
        }
    }
}