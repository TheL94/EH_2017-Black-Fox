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
        }
        
        public override void OnUpdate()
        {
            if (OnStateEnd != null)
                OnStateEnd();
        }
    }
}
