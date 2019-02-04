using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{ 
    public class DualBarreledFirearm : BaseWeapon
    {
        [SerializeField]
        private Transform firepoint1;
        [SerializeField]
        private Transform firepoint2;

        protected override void FireAction()
        {
            BaseAmmo bullet1 = Instantiate(bulletPrefab);
            bullet1.Initialize(ShootForce, firepoint1);

            BaseAmmo bullet2 = Instantiate(bulletPrefab);
            bullet2.Initialize(ShootForce, firepoint2);
        }
    }
}