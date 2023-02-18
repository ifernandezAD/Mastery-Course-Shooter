using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 5;
    private int currentHealth;

    public event Action OnTookHit = delegate { };
    public event Action OnDied = delegate { };

    private void OnEnable()
    {
        currentHealth = health;
    }

    public void Takehit(int amount)
    {
        if (currentHealth <= 0)
        {
            return;
        }

        currentHealth -= amount;
        if (currentHealth > 0)
        {
            OnTookHit();
        }
        else
        {
            OnDied();
        }


    }
}
