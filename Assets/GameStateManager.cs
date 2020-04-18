using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GameStateManager : MonoBehaviour
{  
    public static GameStateManager Instance;
    public GameState _GameState = GameState.Shooty;
    public int activeEnemies = 0;

    public bool forceNextWave = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    private void Update()
    {
        if(forceNextWave)
        {
            forceNextWave = false;
            _GameState = GameState.Shooty;
        }
    }
}

public enum GameState
{
    Shooty,
    Scenario,
    Pause
}
