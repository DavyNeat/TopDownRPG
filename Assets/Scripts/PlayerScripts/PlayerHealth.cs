using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, HurtResponder
{
    [SerializeField] private int health;
    [SerializeField] private int maxHealth;
    [SerializeField] private int healthPoints;
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
        float currPercent = percentHealth();
        maxHealth = Mathf.RoundToInt(Mathf.Sqrt(healthPoints)) * healthPoints;
        health = Mathf.RoundToInt(maxHealth * currPercent);
    }

    public float percentHealth()
    {
        float percentHealth = (float)health / (float)maxHealth;
        return percentHealth;
    }

    // Start is called before the first frame update
    void Start()
    {
        healthPoints = 10;
        maxHealth = Mathf.RoundToInt(Mathf.Sqrt(healthPoints)) * healthPoints;
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
