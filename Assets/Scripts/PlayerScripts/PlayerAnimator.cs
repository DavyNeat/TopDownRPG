using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;
    private string currentState;
    [SerializeField] private PlayerMovement movement;
    void Start()
    {
        animator = GetComponent<Animator>();
        currentState = "PlayerIdle";
        animator.Play(currentState);
    }

    void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;
        animator.Play(newState);
        currentState = newState;
    }

    void Update()
    {
        if (movement.isDashing())
        {
            ChangeAnimationState("PlayerDash");
        }
        else if (movement.isMoving())
        {
            ChangeAnimationState("PlayerWalking");
        }
        else
        {
            ChangeAnimationState("PlayerIdle");
        }
    }
}
