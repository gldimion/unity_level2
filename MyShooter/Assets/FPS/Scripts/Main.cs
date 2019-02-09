using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class Main : MonoBehaviour
    {
        public static Main Instance { get; private set; }

        public event Action<PlayerModel> PlayerChanged;

        public PlayerModel PlayerModel { get; private set; }
        public InputController InputController { get; private set; }
        public FlashlightController FlashlightController { get; private set; }
        public WeaponsController WeaponsController { get; private set; }
        public TeammateController TeammateController { get; private set; }

        private void Awake()
        {
            if (Instance) Destroy(gameObject);
            else Instance = this;
        }

        private void Start()
        {
            InputController = gameObject.AddComponent<InputController>();
            FlashlightController = gameObject.AddComponent<FlashlightController>();
            WeaponsController = gameObject.AddComponent<WeaponsController>();
            TeammateController = gameObject.AddComponent<TeammateController>();
        }

        public void SetPlayer(PlayerModel player)
        {
            PlayerModel = player;
            PlayerChanged?.Invoke(player);
        }
    }
}