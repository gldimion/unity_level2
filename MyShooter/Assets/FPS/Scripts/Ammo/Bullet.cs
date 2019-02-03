using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class Bullet : BaseAmmo
    {
        private float speed;
        private bool isHitted;

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

            RaycastHit hit;
            if (Physics.Linecast(Transform.position, finalPos, out hit))
            {
                isHitted = true;
                Transform.position = hit.point;

                IDamageable damageable = hit.collider.GetComponent<IDamageable>();
                if (damageable != null) damageable.ApplyDamage(damage, Transform.forward);

                Destroy(GameObject, 0.3f);
            }
            else
            {
                Transform.position = finalPos;
            }
        }
    }
}