using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : Health
{
    public static PlayerHealth Instance;

    SpriteRenderer sprite => GetComponentInChildren<SpriteRenderer>();
    private void Awake()
    {
        Instance = this;
    }


    public void DoRefill()
    {
        currentHealth = MaxHealth;
        sprite.color = Color.white;
    }

    public override void TakeDamage(float amount)
    {
        base.TakeDamage(amount);

        var spriteColor = Color.Lerp(Color.black, Color.white, currentHealth / MaxHealth);
        sprite.color = spriteColor;
    }

    protected override void Die()
    {
        GameOver.Instance.HandleGameOver();
    }
}
