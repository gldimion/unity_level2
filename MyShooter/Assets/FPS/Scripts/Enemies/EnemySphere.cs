using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{ 
    public class EnemySphere : BaseEnemy
    {
        protected override void OnDamage(float damage, Vector3 damageDirection)
        {
            float healthState = Health / maxHealth;
            Color = new Color(healthState, healthState, healthState);
            if (Rigidbody) Rigidbody.AddForce(-2 * damageDirection * 100f / Rigidbody.mass);
        }
    }
}