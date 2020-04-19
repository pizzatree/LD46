using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHealth : Health
{
    private SpriteRenderer sprite => GetComponent<SpriteRenderer>();

    [SerializeField]
    private bool door = false;
    public override void TakeDamage(float amount)
    {
        base.TakeDamage(amount);

        if (!door)
        {
            var wallColor = Color.Lerp(Color.red, Color.green, currentHealth / MaxHealth);
            sprite.color = wallColor;
        }
    }

    // override Die and add debris explosion
}
