using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, HurtResponder
{
    [SerializeField] private int health;
    [SerializeField] private int maxHealth;
    [SerializeField] private int healthPoints;
    [SerializeField] private int modifier;
    private List<BasicHurtBox> hurtBoxes = new List<BasicHurtBox>();
    public bool checkHit(HitData data)
    {
        health -= data.damage;
        return true;
    }

    public void Response(HitData data)
    {
    }

    public void upgradeHealth(int amount)
    {
        healthPoints += amount;
        float percentHealth = (float)health / (float)maxHealth;
        maxHealth = Mathf.RoundToInt(Mathf.Sqrt(healthPoints)) * modifier;
        health = Mathf.RoundToInt(maxHealth * percentHealth);
    }

    // Start is called before the first frame update
    void Start()
    {
        modifier = 20;
        healthPoints = 10;
        maxHealth = Mathf.RoundToInt(Mathf.Sqrt(healthPoints)) * modifier;
        health = maxHealth;
        hurtBoxes = new List<BasicHurtBox>(GetComponentsInChildren<BasicHurtBox>());
        foreach (BasicHurtBox hurtBox in hurtBoxes)
        {
            hurtBox.hurtResponder = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            print("Dead :^(");
        }
    }
}
