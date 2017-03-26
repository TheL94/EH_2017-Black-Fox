﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rope;

namespace BlackFox {
    public class RopeManager : MonoBehaviour {

        public GameObject RopeOrigin;
        List<GameObject> ropes = new List<GameObject>();
        public Material[] RopeColors = new Material[4];
        #region Event
        /// <summary>
        /// React to OnAgentSpawn by building and connectig to it a new rope
        /// </summary>
        /// <param name="_agent"></param>
        private void HandleOnAgentSpawn(Agent _agent)
        {
            AttachNewRope(_agent);
        }
        /// <summary>
        /// React to OnAgentKilled by destroying the rope attached to it
        /// </summary>
        /// <param name="_killer"></param>
        /// <param name="_victim"></param>
        private void HandleOnAgentKilled(Agent _killer, Agent _victim)
        {
            DestroyRope(_victim);
        }

        /// <summary>
        /// React to OnCoreDeath by destroying the rope attached to every player
        /// </summary>
        private void HandleOnCoreDeath()
        {
            foreach (GameObject rope in ropes)
            {
                Destroy(rope);
            }
        }

        private void OnEnable()
        {
            EventManager.OnCoreDeath += HandleOnCoreDeath;
            EventManager.OnAgentSpawn += HandleOnAgentSpawn;
            EventManager.OnAgentKilled += HandleOnAgentKilled;
        }
        private void OnDisable()
        {
            EventManager.OnCoreDeath -= HandleOnCoreDeath;
            EventManager.OnAgentSpawn -= HandleOnAgentSpawn;
            EventManager.OnAgentKilled -= HandleOnAgentKilled;
        }
        #endregion

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
            switch (_target.playerIndex)
            {
                case XInputDotNetPure.PlayerIndex.One:
                    newOrigin.GetComponent<LineRenderer>().material = RopeColors[0];
                    break;
                case XInputDotNetPure.PlayerIndex.Two:
                    newOrigin.GetComponent<LineRenderer>().material = RopeColors[1];
                    break;
                case XInputDotNetPure.PlayerIndex.Three:
                    newOrigin.GetComponent<LineRenderer>().material = RopeColors[2];
                    break;
                case XInputDotNetPure.PlayerIndex.Four:
                    newOrigin.GetComponent<LineRenderer>().material = RopeColors[3];
                    break;
                default:
                    break;
            }

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
