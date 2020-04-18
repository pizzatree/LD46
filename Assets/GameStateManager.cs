using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;
    public GameState GameState = GameState.Shooty;
    public int activeEnemies = 0;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }
}

public enum GameState
{
    Shooty,
    Scenario,
    Pause
}
