using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class GameStateManager : MonoBehaviour
{  
    public static GameStateManager Instance;
    public GameState _GameState = GameState.Shooty;
    public int activeEnemies = 0;

    public bool forceNextWave = false;
    private GameObject player;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    private void Update()
    {
        if(forceNextWave)
        {
            ResumeShooty();
        }
    }

    public void ResumeShooty()
    {
        player.SetActive(true);
        _GameState = GameState.Shooty;
    }

    public void LaunchScenario()
    {
        player.SetActive(false);
        _GameState = GameState.Scenario;
    }
}

public enum GameState
{
    Shooty,
    Scenario,
    Pause
}
