using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth;
    public int health;
    void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void addhealth(int health)
    {
        health = Mathf.Min(health + this.health, maxHealth);
    }

    public void removeHealth(int health)
    {
        health -= health;
    }
}
