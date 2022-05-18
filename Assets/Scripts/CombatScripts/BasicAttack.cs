using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : MonoBehaviour, HitResponder
{
    public int damage => 10;
    [SerializeField] private Hitbox hitBox;
    [SerializeField] private MenuAnimator menuAnimator;
    [SerializeField] private bool attack;
    [SerializeField] private float attackCoolDown;
    [SerializeField] private float coolDownUpgradeRate;
    public bool canAttack;
    private float countDown;
    private bool attacking;
    private RaycastHit2D[] hitObjs;

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
        print(attackCoolDown);
    }

    // Start is called before the first frame update
    void Start()
    {
        hitBox = GetComponent<Hitbox>();
        hitBox.hitResponder = this;
        countDown = 0f;
        canAttack = true;
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
