using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{ 
    public abstract class BaseWeapon : BaseSceneObject
    {
        public BaseAmmo bulletPrefab;
        public float ShootForce;
        public float ReloadTime;
        public float Timeout;

        protected float lastShotTime;

        public virtual void Fire()
        {
            if (Time.time - lastShotTime < Timeout) return;
            lastShotTime = Time.time;

            FireAction();
        }

        protected abstract void FireAction();
    }
}