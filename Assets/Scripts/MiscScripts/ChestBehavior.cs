using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestBehavior : MonoBehaviour
{
    [SerializeField] private float bounceAmount;
    [SerializeField] private float bounceSpeed;
    private Animator animator;
    private Transform chestTransform;
    private float newPos;
    private void Start()
    {
        animator = GetComponent<Animator>();
        chestTransform = GetComponent<Transform>();
        animator.Play("ChestClosed");
        newPos = transform.position.y - bounceAmount;
    }

    private void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("ChestOpen"))
        {
            chestTransform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, newPos, 0f), bounceSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Weapon" && animator.GetCurrentAnimatorStateInfo(0).IsName("ChestClosed"))
            animator.Play("ChestOpen");
        
    }
}
