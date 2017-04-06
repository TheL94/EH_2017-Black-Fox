﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BlackFox {

    public class AvatarUI : MonoBehaviour {
        public Image KillToview;
        public Image Ring;
        //public Text BulletCount;
        public Text KillPoint;
        
        Avatar agent;
        LevelManager levelManager;

        // Use this for initialization
        void Awake() {
            agent = GetComponentInParent<Avatar>();
            Ring.color = Color.green;
        }

        private void Start()
        {
            levelManager = GameManager.Instance.LevelMng;
        }

        // Update is called once per frame
        void Update() {
            //UpdateAmmoUI();
        }

        private void OnEnable() {
            agent.OnDataChange += OnDataChange;
            EventManager.OnPointsUpdate += SetKillPointUI;
        }

        //void UpdateAmmoUI()
        //{
        //    if (BulletCount != null)
        //        BulletCount.text = agent.GetShooterReference().ammo.ToString();
        //}

        void OnDataChange(Avatar _agent) {
            // Aggiorno la UI
            Ring.fillAmount =  _agent.Life / _agent.MaxLife;
            if (Ring.fillAmount < 0.3f) {
                Ring.color = Color.red;
            } else if (Ring.fillAmount > 0.7f) {
                Ring.color = Color.green;
            } else {
                Ring.color = Color.yellow;
            }
                
        }

         void SetKillPointUI()
        {
                //Aggiungi un punto alla UI.
                if (KillPoint != null)
                    KillPoint.text = "Kill:" + (levelManager.GetPlayerKillPoints(agent.playerIndex)).ToString();
        }

        private void OnDisable() {
            agent.OnDataChange -= OnDataChange;
            EventManager.OnPointsUpdate -= SetKillPointUI;
        }
        public void Killview()
        {
            if(KillPoint != null)
                KillPoint.text="+1"+ (levelManager.GetPlayerKillPoints(agent.playerIndex)).ToString();
         
        }


    }
}