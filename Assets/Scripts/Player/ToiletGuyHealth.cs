using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToiletGuyHealth : Health
{
    public static ToiletGuyHealth Instance;
    private void Awake()
    {
        Instance = this;
    }

    public void Replenish() => currentHealth = MaxHealth;

    protected override void Die()
    {
        GameOver.Instance.HandleGameOver();
    }
}
