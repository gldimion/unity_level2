using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class FlashlightModel : MonoBehaviour
    {
        public event Action<bool> FlashlightStateChanged;
        public event Action<float> FlashlightEnergyChanged;

        public bool IsOn { get { return _light.enabled; } }

        private Light _light;

        private float maxEnergy;
        private float curEnergy;
        private float depleteSpeed;
        private float chargeSpeed;

        private void Awake()
        {
            _light = GetComponent<Light>();

            maxEnergy = 10f;
            curEnergy = maxEnergy;
            depleteSpeed = 1f;
            chargeSpeed = 2f;
        }

        public void On()
        {
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

        private void RemoveEnergy(float energy)
        {
            curEnergy -= energy;
            if(curEnergy <= 0)
            {
                curEnergy = 0f;
                Off();
            }

            FlashlightEnergyChanged?.Invoke(curEnergy/maxEnergy);
        }

        private void AddEnergy(float energy)
        {
            if (curEnergy == maxEnergy) return;

            curEnergy += energy;
            if (curEnergy >= maxEnergy)
                curEnergy = maxEnergy;

            FlashlightEnergyChanged?.Invoke(curEnergy/maxEnergy);
        }

        private void Update()
        {
            if (IsOn) RemoveEnergy(depleteSpeed * Time.deltaTime);
            else AddEnergy(chargeSpeed * Time.deltaTime);
        }

    }
}