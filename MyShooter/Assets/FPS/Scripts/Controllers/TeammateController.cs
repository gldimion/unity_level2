using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{ 
    public class TeammateController : MonoBehaviour
    {
        public static event Action<TeammateModel> TeammateSelected;

        private TeammateModel currentTeammate;

        public void MoveCommand()
        {
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit))
            {
                Debug.Log(hit.collider.gameObject.name);
                var teammate = hit.collider.GetComponent<TeammateModel>();
                if (teammate) SelectTeammate(teammate);
                else if (currentTeammate) currentTeammate.SetDestination(hit.point);
            }
        }

        public void SelectTeammate(TeammateModel teammate)
        {
            currentTeammate = teammate;
            TeammateSelected?.Invoke(currentTeammate);
        }
    }
}