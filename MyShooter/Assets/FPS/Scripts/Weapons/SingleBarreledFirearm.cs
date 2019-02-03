using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{ 
    public class SingleBarreledFirearm : BaseWeapon
    {
        [SerializeField]
        private Transform firepoint;

        protected override void FireAction()
        {
            BaseAmmo bullet = Instantiate(bulletPrefab);
            bullet.Initialize(ShootForce, firepoint);
        }
    }
}