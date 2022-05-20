using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour, HitResponder
{
    [SerializeField] private Hitbox hitBox;
    [SerializeField] private MenuAnimator menuAnimator;
    [SerializeField] private bool attack;
    [SerializeField] private float attackCoolDown;
    [SerializeField] private float coolDownUpgradeRate;
    public bool canAttack;
    private float countDown;
    private bool attacking;
    private RaycastHit2D[] hitObjs;
    private int combinedDamage;
    private int baseDamage;
    private int weaponDamage;

    public int damage => combinedDamage;

    public bool checkHit(HitData data)
    {
        return true;
    }

    public void Response(HitData data)
    {
        
    }

    public void updateCooldown(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            attackCoolDown -= attackCoolDown * coolDownUpgradeRate;
        }
    }

    public void upgradeBaseDamage(int amount)
    {
        baseDamage += amount;
        combinedDamage = weaponDamage + baseDamage;
    }

    public void updateWeaponDamage(int amount)
    {
        weaponDamage = amount;
        combinedDamage = weaponDamage + baseDamage;
    }

    // Start is called before the first frame update
    void Start()
    {
        hitBox = GetComponent<Hitbox>();
        hitBox.hitResponder = this;
        countDown = 0f;
        canAttack = true;
        baseDamage = 0;
        weaponDamage = 10;
        combinedDamage = weaponDamage + baseDamage;
    }

    // Update is called once per frame
    void Update()
    {
        if(countDown > 0)
            countDown -= Time.deltaTime;

        canAttack = !menuAnimator.menuShowing;

        if(Input.GetMouseButton(0))
        {
            if (countDown <= 0 && canAttack)
            {
                print("attacking");
                hitBox.checkHit();
                countDown = attackCoolDown;
            }
        }
    }
}
