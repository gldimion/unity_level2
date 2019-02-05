using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class BaseEnemy : BaseSceneObject, IDamageable
    {
        public float Health = 100f;
        protected float maxHealth;

        public float CurrentHealth => Health;

        protected override void Awake()
        {
            base.Awake();
            maxHealth = Health;
        }

        protected virtual void OnDamage(float damage, Vector3 damageDirection)
        {
        }

        public void ApplyDamage(float damage, Vector3 damageDirection)
        {
            if (Health <= 0) return;

            Armor armor = Transform.GetComponent<Armor>();
            if (armor)
                damage *= armor.DamageMultiplyer;

            Health -= damage;
            OnDamage(damage, damageDirection);

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