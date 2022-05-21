using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour, HitResponder
{
    [SerializeField] private CompHitbox hitBox;
    [SerializeField] private MenuAnimator menuAnimator;
    [SerializeField] private bool attack;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float coolDownUpgradeRate;
    [SerializeField] private WeaponAttackMovement attackAnimator;
    public bool canAttack;
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

    public void upgradeAttackSpeed(int level)
    {
        if (level <= 0)
            return;
        attackSpeed = 1 + Mathf.Log10(level);
        print($"attack speed: {attackSpeed}");
        print($"level: {level}");
        attackAnimator.updateAnimationSpeed(attackSpeed);
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

    void Start()
    {
        hitBox.hitResponder = this;
        canAttack = true;
        attackSpeed = 1f;
        baseDamage = 0;
        weaponDamage = 10;
        combinedDamage = weaponDamage + baseDamage;
    }

    void Update()
    {

        canAttack = !menuAnimator.menuShowing && attackAnimator.isIdle();


        if(Input.GetMouseButton(0))
        {
            if (canAttack)
            {
                attackAnimator.playBasicSwing();
            }
        }
    }
}
