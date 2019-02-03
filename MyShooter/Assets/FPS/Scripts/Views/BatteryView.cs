using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FPS
{
    public class BatteryView : MonoBehaviour
    {
        private FlashlightModel model;
        private Image fillImage;

        private void Awake()
        {
            model = FindObjectOfType<FlashlightModel>();
            fillImage = GetComponent<Image>();

            model.FlashlightEnergyChanged += OnFlashlightEnergyChanged;
        }

        private void OnFlashlightEnergyChanged(float fill)
        {
            fillImage.fillAmount = fill;
        }

        private void OnDestoy()
        {
            if(model) model.FlashlightEnergyChanged -= OnFlashlightEnergyChanged;
        }
    }
}