using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHealth : Health
{
    private SpriteRenderer sprite => GetComponent<SpriteRenderer>();

    public override void TakeDamage(float amount)
    {
        base.TakeDamage(amount);

        var wallColor = Color.Lerp(Color.red, Color.green, currentHealth / MaxHealth);
        sprite.color = wallColor;
    }

    // override Die and add debris explosion
}
