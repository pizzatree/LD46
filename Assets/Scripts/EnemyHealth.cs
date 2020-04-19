using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    protected override void Die()
    {
        --GameStateManager.Instance.activeEnemies;
        base.Die();
    }
}
