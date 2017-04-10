﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlackFox
{
    public static class EventManager
    {
        #region AgentSpawn
        public delegate void AgentSpawnEvent(Avatar _agent);
        /// <summary>
        /// Evento chiamato al respawn di un agente
        /// </summary>
        public static AgentSpawnEvent OnAgentSpawn;
        #endregion

        #region AgentKilledEvent
        public delegate void AgentKilledEvent(Avatar _killer, Avatar _victim);
        /// <summary>
        /// Evento chiamato alla morte di un agente
        /// </summary>
        public static AgentKilledEvent OnAgentKilled;
        #endregion

        #region LevelEvent
        public delegate void LevelEvent(string _eventName);

        /// <summary>
        /// Evento chiamato alla morte del core o alla vittoria dell'agente che innesca il cambio di stato della GameplaySM
        /// </summary>
        public static LevelEvent TriggerPlayStateEnd;
        #endregion

        #region UIEvent
        public delegate void UIEvent();
        /// <summary>
        /// Evento che si occupa di innescare l'update dei punti sulla UI
        /// </summary>
        public static UIEvent OnPointsUpdate;       
        #endregion
    }
}