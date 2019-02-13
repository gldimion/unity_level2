using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class EmissionBullet : Bullet
    {
        [SerializeField]
        private ParticleSystem[] emitters;

        protected override void BulletHittedAction()
        {
            foreach (ParticleSystem e in emitters)
                e.Stop();
        }
    }
}