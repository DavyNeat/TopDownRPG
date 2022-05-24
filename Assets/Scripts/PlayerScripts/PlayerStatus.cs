using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour, HurtResponder
{
    [SerializeField] private int health;
    [SerializeField] private int maxHealth;
    [SerializeField] private int healthPoints;
    [SerializeField] private float stamina;
    [SerializeField] private float maxStamina;
    [SerializeField] private float exhaustAmount;
    private bool exhausted;
    private float exhaustCounter;
    private List<BasicHurtBox> hurtBoxes = new List<BasicHurtBox>();
    private PlayerMovement movement;
    void Start()
    {
        healthPoints = 10;
        maxHealth = Mathf.RoundToInt(Mathf.Sqrt(healthPoints)) * healthPoints;
        health = maxHealth;

        maxStamina = 10f;
        stamina = maxStamina;
        exhaustCounter = 0f;

        hurtBoxes = new List<BasicHurtBox>(GetComponentsInChildren<BasicHurtBox>());
        foreach (BasicHurtBox hurtBox in hurtBoxes)
        {
            hurtBox.hurtResponder = this;
        }

        movement = GetComponent<PlayerMovement>();
    }

    void Update()
    {

        if (stamina <= 0f && exhaustCounter <= 0f)
        {
            exhausted = true;
            stamina = 0;
            exhaustCounter = exhaustAmount;
        }

        if (exhausted)
        {
            exhaustCounter -= Time.deltaTime;

            if (exhaustCounter <= 0)
                exhausted = false;
        }

        if (movement.isSprinting())
        {
            stamina -= 2f * Time.deltaTime;
        }
        else if (exhaustCounter <= 0f && stamina < maxStamina)
        {
            exhaustCounter = 0f;
            stamina += Time.deltaTime;
        }

        if (health <= 0)
        {
            print("Dead :^(");
        }
    }

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

    public void upgradeStamina(int amount)
    {

    }

    public float percentStamina()
    {
        return stamina / maxStamina;
    }

    public float currentStamina()
    {
        return stamina;
    }
}
