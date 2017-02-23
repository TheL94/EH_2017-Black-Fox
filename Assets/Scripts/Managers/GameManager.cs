﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    public int KillPoint;
    public int DeathPoint;
    public int PointsToWin;

    public bool dontDestroyOnLoad;
    //Variabile che contiene il valore della vita del core
    public float coreLife = 10;

    public SceneController sceneController;
    PointsManager pointsManager;

    public float CoreLife
    {
        get
        {
            return coreLife;
        }
        set
        {
            coreLife = value;
        }
    }

    private void Awake()
    {
        if (dontDestroyOnLoad)
        {
            DontDestroyOnLoad(gameObject);
        }
        if (Instance == null)
        {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
        
        sceneController = FindObjectOfType<SceneController>();
    }

    // Use this for initialization
    void Start () {
        //core = FindObjectOfType<Core>();
        pointsManager = new PointsManager(KillPoint, DeathPoint, PointsToWin);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void SetKillPoints(PlayerIndex _killer, PlayerIndex _victim)
    {
        pointsManager.UpdateKillPoints(_killer, _victim);
    }
}

