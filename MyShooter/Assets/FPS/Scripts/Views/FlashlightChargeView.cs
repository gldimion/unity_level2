using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FPS
{
    public class FlashlightChargeView : MonoBehaviour
    {
        private FlashlightModel model;
        private Image fillImage;

        private void Awake()
        {
            model = FindObjectOfType<FlashlightModel>();
            fillImage = GetComponent<Image>();

            model.ChargeAmountChanged += OnChargeAmountChanged;
        }

        private void OnChargeAmountChanged(float amount)
        {
            if (Mathf.Abs(fillImage.fillAmount - amount) < 0.01f) return;
            fillImage.fillAmount = amount;
        }

        private void OnDestoy()
        {
            if(model) model.ChargeAmountChanged -= OnChargeAmountChanged;
        }
    }
}