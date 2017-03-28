﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BlackFox
{
    /// <summary>
    /// Reppresenta lo stato di gameplay della flow state machine.
    /// </summary>
    public class GameplayState : StateBase
    {
        int levelNumber = 1;

        public override void OnStart()
        {
            Debug.Log("GameplayState");
            StateMachineBase.OnMachineEnd += OnMachineEnd;
            GameManager.Instance.InstantiateLevelManager();
            LoadArena();
        }

        public override void OnEnd()
        {
            StateMachineBase.OnMachineEnd -= OnMachineEnd;
        }

        /// <summary>
        /// Istanzia il Livello
        /// </summary>
        void LoadArena()
        {
            //GameObject.Instantiate(Resources.Load("Prefabs/Levels/Level" + levelNumber));
            GameObject.Instantiate(Resources.Load("Prefabs/Levels/Level1withRopes"));
        }

        void OnMachineEnd(string _machineName)
        {
            if(_machineName == "GameplaySM")
            {
                Debug.Log("GameplaySM_Stop");
                if (OnStateEnd != null)
                    OnStateEnd();
            }   
        }
    }
}
