using System;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    [SerializeField]
    protected float MaxHealth = 10f;

    protected float currentHealth;
    public event Action OnTakeDamage = delegate { };

    private void Start()
    {
        currentHealth = MaxHealth;
    }

    public virtual void TakeDamage(float amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
            Die();
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
