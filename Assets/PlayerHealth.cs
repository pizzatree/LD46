using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Debug.Log("Game over");
    }
}
