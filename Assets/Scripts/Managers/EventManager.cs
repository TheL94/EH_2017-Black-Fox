﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlackFox
{

    public static class EventManager
    {
        

        #region AgentSpawn
        public delegate void AgentSpawnEvent(Agent _agent);
        /// <summary>
        /// Evento chiamato al respawn di un agente
        /// </summary>
        public static AgentSpawnEvent OnAgentSpawn;
        #endregion

        #region AgentKilledEvent

        public delegate void AgentKilledEvent(Agent _killer, Agent _victim);
        /// <summary>
        /// Evento chiamato alla morte di un agente
        /// </summary>
        public static AgentKilledEvent OnAgentKilled;

        #endregion

        #region LevelEvent

        public delegate void LevelEvent();

        /// <summary>
        /// Evento chiamato alla morte del core o alla vittoria dell'agente che innesca il cambio di stato della GameplaySM
        /// </summary>
        public static LevelEvent TriggerPlayStateEnd;

        public delegate void UIEvent();
        /// <summary>
        /// Evento che si occupa di innescare l'update dei punti sulla UI
        /// </summary>
        public static UIEvent OnPointsUpdate;
        
        #endregion
    }
}