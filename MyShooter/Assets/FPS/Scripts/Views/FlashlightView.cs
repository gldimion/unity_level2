using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FPS
{
    public class FlashlightView : MonoBehaviour
    {
        public Color ColorOn;
        public Color ColorOff;

        private FlashlightModel model;
        private Image image;

        private void Awake()
        {
            model = FindObjectOfType<FlashlightModel>();
            image = GetComponent<Image>();

            model.FlashlightStateChanged += OnFlashlightStateChanged;
        }

        private void OnFlashlightStateChanged(bool state)
        {
            image.color = state ? ColorOn : ColorOff;
        }

        private void OnDestoy()
        {
            if(model) model.FlashlightStateChanged -= OnFlashlightStateChanged;
        }
    }
}