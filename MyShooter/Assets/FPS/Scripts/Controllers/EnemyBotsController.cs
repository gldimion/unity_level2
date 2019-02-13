using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{ 
    public class EnemyBotsController : BaseController
    {
        private List<EnemyBot> botList = new List<EnemyBot>();
        private Transform targetTramsform;

        private IEnumerator Start()
        {
            yield return new WaitWhile(() => !Main.Instance && !Main.Instance.PlayerModel);

            targetTramsform = Main.Instance.PlayerModel.transform;
            SetTarget(targetTramsform);
            foreach (var bot in FindObjectsOfType<EnemyBot>()) AddBot(bot);
        }

        public void SetTarget(Transform target)
        {
            foreach (var bot in botList) bot.SetTarget(target);
        }

        public void AddBot(EnemyBot bot)
        {
            if (botList.Contains(bot)) return;
            botList.Add(bot);
            bot.SetTarget(targetTramsform);
        }

        public void RemoveBot(EnemyBot bot)
        {
            if (!botList.Contains(bot)) return;
            botList.Remove(bot);
        }
    }
}