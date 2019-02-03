using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{ 
    public class Box : BaseSceneObject, IDamageable
    {
        public float Health = 100f;

        public float CurrentHealth => Health;

        public void ApplyDamage(float damage, Vector3 damageDirection)
        {
            if (Health <= 0) return;

            Health -= damage;
            Color = Random.ColorHSV();
            if (Rigidbody) Rigidbody.AddForce(damageDirection * 100f / Rigidbody.mass);

            if (Health <= 0) Die();
        }

        public void Die()
        {
            Color = Color.red;
            Collider.enabled = false;
            Destroy(GameObject, 3f);
        }
    }
}