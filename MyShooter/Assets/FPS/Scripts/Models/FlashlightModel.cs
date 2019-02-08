using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class FlashlightModel : MonoBehaviour
    {
        public event Action<bool> FlashlightStateChanged;
        public event Action<float> ChargeAmountChanged;

        public bool IsOn { get { return _light.enabled; } }

        public float ChargeUpdateTime = 0.5f;
        public float RechargeTime = 5f;
        public float DrainMult = 2f;

        private float chargeAmount;
        private Light _light;

        private void Awake()
        {
            _light = GetComponent<Light>();
            chargeAmount = 1f;
        }

        private void OnEnable()
        {
            StartCoroutine(ChangeCharge());
        }

        private void OnDisable()
        {
            StopCoroutine(ChangeCharge());
        }

        public void On()
        {
            if (chargeAmount < 0.3f) return;
            if (!_light) return;
            _light.enabled = true;

            FlashlightStateChanged?.Invoke(true);
        }

        public void Off()
        {
            if (!_light) return;
            _light.enabled = false;

            FlashlightStateChanged?.Invoke(false);
        }

        private IEnumerator ChangeCharge()
        {
            while(true)
            { 
                yield return new WaitForSeconds(ChargeUpdateTime);
                if (IsOn)
                {
                    chargeAmount = Mathf.Clamp01(chargeAmount - 1f / Mathf.Max(0.01f, RechargeTime * DrainMult) * ChargeUpdateTime);
                    if (chargeAmount <= Mathf.Epsilon) Off();
                }
                else
                {
                    chargeAmount = Mathf.Clamp01(chargeAmount + 1f / Mathf.Max(0.01f, RechargeTime) * ChargeUpdateTime);
                }
                ChargeAmountChanged?.Invoke(chargeAmount);
            }
        }
    }
}