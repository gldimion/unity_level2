using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FPS
{ 
    public class InputController : BaseController
    {
        private void Update()
        {
            if (Input.GetButtonDown("SwitchFlashlight"))
                Main.Instance.FlashlightController.SwitchFlashlight();
        }
    }
}