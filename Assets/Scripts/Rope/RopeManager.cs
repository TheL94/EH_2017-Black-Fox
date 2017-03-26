﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rope;

namespace BlackFox {
    public class RopeManager : MonoBehaviour {

        public GameObject RopeOrigin;
        List<GameObject> ropes = new List<GameObject>();

        private void HandleOnAgentSpawn(Agent _agent)
        {
            AttachNewRope(_agent);
        }

        private void HandleOnAgentKilled(Agent _killer, Agent _victim)
        {
            DestroyRope(_victim);
        }

        private void OnEnable()
        {
            EventManager.OnAgentSpawn += HandleOnAgentSpawn;
            EventManager.OnAgentKilled += HandleOnAgentKilled;
        }
        private void OnDisable()
        {
            EventManager.OnAgentSpawn -= HandleOnAgentSpawn;
            EventManager.OnAgentKilled -= HandleOnAgentKilled;
        }

    #region API
        /// <summary>
        /// Create a new Rope and attach it to _target(parameter)
        /// </summary>
        /// <param name="_target"></param>
        public void AttachNewRope(Agent _target)
        {
            GameObject newOrigin;
            
            newOrigin = Instantiate(RopeOrigin, transform);
            newOrigin.name = _target.playerIndex + "Rope";
            //Set the AnchorPoint before the activation of the component
            newOrigin.GetComponent<RopeController>().AnchorPoint = _target.GetComponent<ConfigurableJoint>().connectedBody.transform;
            newOrigin.GetComponent<RopeController>().InitRope();

            ropes.Add(newOrigin);            
        }
        /// <summary>
        /// Find the Rope attached to _target and destroy it
        /// </summary>
        /// <param name="_target"></param>
        public void DestroyRope(Agent _target)
        {
            string nameOfRope = _target.playerIndex + "Rope";
            foreach (GameObject gObj in ropes)
            {
                if (gObj.name == nameOfRope)
                {
                    Destroy(gObj);
                    break;
                }                    
            }
        }
    #endregion
    }
}
