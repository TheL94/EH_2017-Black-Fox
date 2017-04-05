﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlackFox
{
    public class MainMenuState : StateBase
    {

        public override void OnStart()
        {
            Debug.Log("MainMenuState");
            GameManager.Instance.UiMng.CreateMainMenu();
            GameManager.Instance.AvatarMng.ChangeAgentSMState(AgentSMStates.MenuInputState);
        }

        public override void OnEnd()
        {
            GameManager.Instance.UiMng.DestroyMainMenu();
        }
    }
}
