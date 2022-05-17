using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicHurtBox : MonoBehaviour, HurtBox
{

    [SerializeField] private bool isActive = true;
    [SerializeField] private GameObject hurtBoxOwner = null;
    private HurtResponder m_hurtResponder;


    public bool active { get => isActive; }

    public GameObject owner { get => hurtBoxOwner; }

    public Transform transform { get => transform; }

    public HurtResponder hurtResponder { get => m_hurtResponder; set => m_hurtResponder = value; }

    public bool checkHit(HitData data)
    {

        if (m_hurtResponder == null)
        {
            print("No Responder");
        }

        return true;
    }
}
