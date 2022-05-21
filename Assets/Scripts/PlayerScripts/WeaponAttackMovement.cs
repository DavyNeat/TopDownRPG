using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttackMovement : MonoBehaviour
{
    [SerializeField] private SpriteRenderer playerSprite;
    private Animator swordAnimator;
    private SpriteRenderer swordSprite;

    void Start()
    {
        swordSprite = GetComponent<SpriteRenderer>();
        swordSprite.sortingOrder = playerSprite.sortingOrder;
        swordAnimator = GetComponent<Animator>();
        swordAnimator.Play("Idle");
    }

    public void playBasicSwing()
    {
        swordAnimator.SetTrigger("swing");
    }

    public bool isIdle()
    {
        return this.swordAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle");
    }

    public void updateAnimationSpeed(float speed)
    {
        swordAnimator.speed = speed;
    }
}
