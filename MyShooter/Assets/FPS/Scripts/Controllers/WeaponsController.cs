using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{ 
    public class WeaponsController : BaseController
    {
        private BaseWeapon[] weapons;
        private int currentWeapon;

        private void Awake()
        {
            Main.Instance.PlayerChanged += OnPlayerChanged;
            if (Main.Instance.PlayerModel) OnPlayerChanged(Main.Instance.PlayerModel);
        }

        private void OnPlayerChanged(PlayerModel player)
        {
            weapons = player.Weapons;
            currentWeapon = 0;
            for (int i = 0; i < weapons.Length; i++)
            {
                weapons[i].IsVisible = i == currentWeapon;
            }
        }

        public void SelectWeapon(int newWeapon)
        {
            if (newWeapon == currentWeapon || newWeapon >= weapons.Length || newWeapon < 0) return;

            weapons[currentWeapon].IsVisible = false;
            currentWeapon = newWeapon;
            weapons[currentWeapon].IsVisible = true;
        }

        public void NextWeapon()
        {
            if (currentWeapon + 1 >= weapons.Length) SelectWeapon(0);
            else SelectWeapon(currentWeapon + 1);
        }

        public void PreviousWeapon()
        {
            if (currentWeapon - 1 < 0) SelectWeapon(weapons.Length - 1);
            else SelectWeapon(currentWeapon - 1);
        }


        public void Fire()
        {
            if (weapons != null && weapons.Length > currentWeapon && weapons[currentWeapon] != null)
                weapons[currentWeapon].Fire();
        }

        private void OnDestroy()
        {
            Main.Instance.PlayerChanged -= OnPlayerChanged;
        }
    }
}