using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : Health
{
    SpriteRenderer sprite => GetComponentInChildren<SpriteRenderer>();

    public override void TakeDamage(float amount)
    {
        base.TakeDamage(amount);

        var spriteColor = Color.Lerp(Color.black, Color.white, currentHealth / MaxHealth);
        sprite.color = spriteColor;
    }

    protected override void Die()
    {
        SceneManager.LoadScene(0);
    }
}
