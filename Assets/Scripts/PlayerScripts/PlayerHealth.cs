using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, HurtResponder
{
    [SerializeField] private int health;
    private List<BasicHurtBox> hurtBoxes = new List<BasicHurtBox>();
    public bool checkHit(HitData data)
    {
        health -= data.damage;
        return true;
    }

    public void Response(HitData data)
    {
    }

    // Start is called before the first frame update
    void Start()
    {
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
