using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class EnemyCylinder : BaseEnemy
    {
        protected override void OnDamage(float damage, Vector3 damageDirection)
        {
            float scale = 1.1f;
            Transform.localScale = new Vector3(Transform.localScale.x * scale, Transform.localScale.y * scale, Transform.localScale.z * scale);
        }
    }
}