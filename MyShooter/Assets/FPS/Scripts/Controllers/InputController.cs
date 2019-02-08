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

            if (Input.GetButtonDown("NextWeapon") || Input.GetAxis("Mouse ScrollWheel") < 0f)
                Main.Instance.WeaponsController.NextWeapon();
            if (Input.GetButtonDown("PreviousWeapon") || Input.GetAxis("Mouse ScrollWheel") > 0f)
                Main.Instance.WeaponsController.PreviousWeapon();

            if (Input.GetKeyDown(KeyCode.Alpha1))
                Main.Instance.WeaponsController.SelectWeapon(0);
            if (Input.GetKeyDown(KeyCode.Alpha2))
                Main.Instance.WeaponsController.SelectWeapon(1);
            if (Input.GetKeyDown(KeyCode.Alpha3))
                Main.Instance.WeaponsController.SelectWeapon(2);
            if (Input.GetKeyDown(KeyCode.Alpha4))
                Main.Instance.WeaponsController.SelectWeapon(3);
            if (Input.GetKeyDown(KeyCode.Alpha5))
                Main.Instance.WeaponsController.SelectWeapon(4);

            if (Input.GetButton("Fire1"))
                Main.Instance.WeaponsController.Fire();
        }
    }
}