using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public static GameOver Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void HandleGameOver()
    {
        SceneManager.LoadScene(0);
    }
}
