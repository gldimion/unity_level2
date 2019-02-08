using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class EmissionBullet : Bullet
    {
        [SerializeField]
        private ParticleSystem[] emitters;

        protected override void Awake()
        {
            base.Awake();
            BulletHitted += OnBulletHitted;
        }

        private void OnBulletHitted()
        {
            foreach (ParticleSystem e in emitters)
                e.Stop();
        }

        private void OnDestroy()
        {
            BulletHitted -= OnBulletHitted;
        }
    }
}