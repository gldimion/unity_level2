using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class Bullet : BaseAmmo
    {
        public event Action BulletHitted;

        [SerializeField]
        protected float selfDestroyTimeAfterHit = 0.3f;

        [SerializeField]
        protected float damageChangeOverTime = 0f;
        private float damageMultiplyer = 1f;

        private float speed;
        private bool isHitted;
        protected float hitDelta = 0f;

        public override void Initialize(float force, Transform firepoint)
        {
            Transform.position = firepoint.position;
            Transform.rotation = firepoint.rotation;
            speed = force;            
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

                BulletHitted?.Invoke();

                Destroy(GameObject, selfDestroyTimeAfterHit);
            }
            else
            {
                Transform.position = finalPos;
                damageMultiplyer += damageChangeOverTime;
            }
        }
    }
}