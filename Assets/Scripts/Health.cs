using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 5;
    private int currentHealth;

    private void OnEnable()
    {
        currentHealth = health;
    }

    public void Takehit(int amount)
    {
        currentHealth -= amount;
        if (currentHealth > 0)
        {
            GetComponentInChildren<Animator>().SetTrigger("Hit");
        }
        else
        {
            GetComponentInChildren<Animator>().SetTrigger("Die");
        }

       
    }
}
