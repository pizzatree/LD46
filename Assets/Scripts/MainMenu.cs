using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;

    private void Start()
    {
        scoreText.text = "Highest Round: \n" + PlayerPrefs.GetInt("HighestRound");
    }
    public void LoadLevel()
    {
        SceneManager.LoadScene(1);
    }
}
