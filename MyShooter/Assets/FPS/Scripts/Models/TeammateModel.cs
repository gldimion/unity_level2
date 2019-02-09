using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

namespace FPS
{ 
    public class TeammateModel : MonoBehaviour
    {
        private NavMeshAgent agent;
        private ThirdPersonCharacter character;

        private void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();

            agent.updateRotation = false;
            agent.updatePosition = true;
        }

        private void Update()
        {
            if (agent.remainingDistance > agent.stoppingDistance)
                character.Move(agent.desiredVelocity, false, false);
            else
                character.Move(Vector3.zero, false, false);
        }

        public void SetDestination(Vector3 pos)
        {
            agent?.SetDestination(pos);
        }
    }
}