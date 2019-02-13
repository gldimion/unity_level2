using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{ 
    public abstract class BaseWeapon : BaseSceneObject
    {
        public string BulletID;
        //public BaseAmmo bulletPrefab;
        public Animator shootAnimator;
        public float ShootForce;
        public float ReloadTime;
        public float Timeout;

        protected float lastShotTime;

        protected override void Awake()
        {
            base.Awake();
            IsVisible = false;
        }

        public virtual void Fire()
        {
            if (Time.time - lastShotTime < Timeout) return;
            lastShotTime = Time.time;

            FireAction();
            if (shootAnimator != null) shootAnimator.SetTrigger("ShootAction");
        }

        protected abstract void FireAction();
    }
}