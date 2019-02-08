using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{ 
    public class EnemyBox : BaseEnemy
    {
        protected override void OnDamage(float damage, Vector3 damageDirection)
        {
            Color = Random.ColorHSV();
            if (Rigidbody) Rigidbody.AddForce(damageDirection * 100f / Rigidbody.mass);
        }
    }
}