using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private bool doorClosed;
    private bool inZone;

    private void Start()
    {
        if(transform.parent.name.Substring(0, 4) == "Door")
            animator.Play("DoorClosed");
        else
            animator.Play("vertDoorClosed");
        doorClosed = true;
        print(transform.parent.name.Substring(0,4));
    }

    private void Update()
    {
        if (inZone && Input.GetKeyDown(KeyCode.E))
        {
            if (transform.parent.name.Substring(0, 4) == "Door")
            {

                if (doorClosed)
                {
                    animator.Play("DoorOpen");
                    doorClosed = false;
                }
                else
                {
                    animator.Play("DoorClosed");
                    doorClosed = true;
                }

            }
            else
            {
                if (doorClosed)
                {
                    animator.Play("vertDoorOpen");
                    doorClosed = false;
                }
                else
                {
                    animator.Play("vertDoorClosed");
                    doorClosed = true;
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
            inZone = true;
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
            inZone = false;
       
    }
}
