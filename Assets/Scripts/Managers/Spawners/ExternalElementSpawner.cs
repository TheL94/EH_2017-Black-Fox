﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlackFox
{
    public class ExternalElementSpawner : SpawnerBase
    {
        new public ExternalElementOptions Options;
        
        Transform target;                                           //Target of the ExternalElements
        float nextTime;                                             //Timer
        List<IDamageable> Damageables = new List<IDamageable>();    //Lista di oggetti danneggiabili

        GameObject container;

        #region Powerup region
        [HideInInspector]
        public bool IsKamikazeTime = false;

        private float _powerupduration;

        public float PowerupDuration
        {
            get { return _powerupduration; }
            set { _powerupduration = value; }
        }

        public void ActiveKamikazeTime(float _time)
        {
            IsKamikazeTime = true;
            PowerupDuration = _time;
        }

        #endregion

        #region SpawnerLifeFlow
        public override void Init()
        {
            if (Options.ExternalAgent == null)
                Options.ExternalAgent = (GameObject)Resources.Load("Prefabs/ExternalAgents/ExternalAgent1");

            target = GameManager.Instance.LevelMng.Core.transform;
            nextTime = Time.time + Random.Range(Options.MinTime, Options.MaxTime);
            LoadIDamageablePrefab();

            container = new GameObject("ExternalAgentContainer");
            container.transform.parent = GameManager.Instance.LevelMng.Arena.transform;
            ID = "ExternalElementSpawner";
        }

        public override SpawnerBase OptionInit(SpawnerOptions options)
        {
            Options = options as ExternalElementOptions;
            return this;
        }

        void Update()
        {
            if(IsActive)
            {
                if (Time.time >= nextTime)
                {
                    InstantiateExternalAgent();
                    if (IsKamikazeTime)
                    {
                        nextTime = Time.time + 1.5f;
                        PowerupDuration -= nextTime;
                        if (PowerupDuration <= 0)
                            IsKamikazeTime = false;

                    }
                    else
                        nextTime = Time.time + Random.Range(Options.MinTime, Options.MaxTime);
                }

                //if (IsKamikazeTime)
                //{
                //    PowerupDuration -= Time.deltaTime;
                //    if (PowerupDuration <= 0)
                //        IsKamikazeTime = false;
                //}


                GravityAround();
            }
        }

        public override void Restart()
        {
            CleanSpawned();
            Init();
        }

        public override void CleanSpawned()
        {
            if(container != null)
                Destroy(container);
        }
        #endregion

        /// <summary>
        /// Rotate around the target position and keep facing it
        /// </summary>
        void GravityAround()
        {
            Vector3 relativePos = target.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos);

            Quaternion current = transform.localRotation;

            transform.localRotation = Quaternion.Slerp(current, rotation, Options.AngularSpeed * Time.deltaTime);
            transform.Translate(Options.TransSpeed * Time.deltaTime, 0, 0);
        }

        /// <summary>
        /// Load damageable items (classes with IDamageable) from prefabs
        /// </summary>
        void LoadIDamageablePrefab()
        {
            //WARNING - If a GameObject in the list do not have the IDamageable interface, it will not be damaged
            List<GameObject> DamageablesPrefabs = PrefabUtily.LoadAllPrefabsWithComponentOfType<IDamageable>("Prefabs", Options.ExternalAgent);
            foreach (var k in DamageablesPrefabs)
            {
                if (k.GetComponent<IDamageable>() != null)
                    Damageables.Add(k.GetComponent<IDamageable>());
            }
        }

        /// <summary>
        /// Instatiate an External Agent
        /// </summary>
        void InstantiateExternalAgent()
        {
            GameObject instantiateEA = Instantiate(Options.ExternalAgent, transform.position, transform.rotation, container.transform);
            ExternalAgent eA = instantiateEA.GetComponent<ExternalAgent>();
            eA.Initialize(target, Damageables);
        }
    }

    [System.Serializable]
    public class ExternalElementOptions : SpawnerOptions {
        public GameObject ExternalAgent;                        //Prefab of the ExternalAgent to instantiate         
        public float MinTime = 10;                              //Min time between Spawns
        public float MaxTime = 20;                              //Max time between Spawns
        public float AngularSpeed = 1;                          //Rotation speed
        public float TransSpeed = 1;                            //Precession speed
    }
}
