using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class LightBullet : Bullet
    {
        [SerializeField]
        protected float HaloMultiplier = 0.01f;
        [SerializeField]
        protected float StartLightRange = 0.5f;
        [SerializeField]
        protected float MaxLightRange = 5f;
        [SerializeField]
        protected float MaxLightRangeTime = 5f;
        [SerializeField]
        protected float LightRangeUpdateTime = 0.1f;

        [SerializeField]
        private Light haloLight;
        [SerializeField]
        private Light realLight;

        private void Start()
        {
            hitDelta = 0.1f;
            realLight.range = StartLightRange;
            haloLight.range = realLight.range * HaloMultiplier;

            StartCoroutine(ChangeLightRange());
        }

        private IEnumerator ChangeLightRange()
        {
            while (true)
            {
                yield return new WaitForSeconds(LightRangeUpdateTime);

                realLight.range += (MaxLightRange - StartLightRange) / MaxLightRangeTime * LightRangeUpdateTime;
                haloLight.range = realLight.range * HaloMultiplier;

                if (realLight.range >= MaxLightRange)
                { 
                    StopCoroutine(ChangeLightRange());
                    break;
                }
            }
        }
    }
}