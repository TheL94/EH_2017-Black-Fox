﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BlackFox
{
    /// <summary>
    /// Costruisce la scena a runtime
    /// </summary>
    public class LevelStartState : StateBase
    {
        public override void OnStart()
        {
            Debug.Log("LevelStartState");
            LoadArena();
            LoadAgents();
            LoadGameElements();
        }
        
        public override void OnUpdate()
        {
            if (OnStateEnd != null)
                OnStateEnd();
        }

        /// <summary>
        /// Istanzia componenti dell'arena
        /// </summary>
        void LoadArena()
        {
            GameObject.Instantiate(Resources.Load("Prefabs/Misc/Floor"));         
        }

        /// <summary>
        /// Istanzia Agenti
        /// </summary>
        void LoadAgents()
        {
            GameObject[] agents = Resources.LoadAll<GameObject>("Prefabs/Agents");

            foreach (GameObject item in agents)
            {
                GameObject.Instantiate(item);
            }
        }

        /// <summary>
        /// Istanzia Elementi di gioco
        /// </summary>
        void LoadGameElements()
        {
            GameObject.Instantiate(Resources.Load("Prefabs/Misc/Core"));
            GameObject.Instantiate(Resources.Load("Prefabs/Misc/LevelManager"));
        }
    }
}