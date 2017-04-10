﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlackFox
{
    public class PreStartState : StateBase
    {
        public override void OnStart()
        {
            GameObject.FindObjectOfType<Counter>().DoCountDown();
            Debug.Log("PreStartState");
            Counter.OnCounterEnded += CounterEnded;
        }

        /// <summary>
        /// Funziona che viene chiamata quando accade un evento di tipo Counter.OnCounterEnded;
        /// </summary>
        void CounterEnded() {
            if (OnStateEnd != null)
            {
                GameManager.Instance.PlayerMng.ChangeAllPlayersState(PlayerState.PlayInputState);
                OnStateEnd();
            }
        }

        public override void OnEnd()
        {
            Counter.OnCounterEnded -= CounterEnded;
        }
    }
}