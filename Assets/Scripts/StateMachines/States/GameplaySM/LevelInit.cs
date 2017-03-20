﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlackFox {

    public class LevelInit : StateBase
    {
        public override void OnStart()
        {
            Debug.Log("LevelInitState");
        }

        public override void OnUpdate()
        {
            if (OnStateEnd != null)
                OnStateEnd();
        }
    }
}