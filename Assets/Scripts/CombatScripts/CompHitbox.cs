using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompHitbox : MonoBehaviour, HitDetector
{
    [SerializeField] private LayerMask m_layerMask;
    private HitResponder m_hitResponder;
    private Animator animator;
    public bool resetCollisions;
    HashSet<Collider2D> colliders;
    public HitResponder hitResponder { get => m_hitResponder; set => m_hitResponder = value; }

    void Start()
    {
        animator = GetComponent<Animator>();
        colliders = new HashSet<Collider2D>();
    }

    void Update()
    {
        if (resetCollisions)
        {
            colliders.Clear ();
            resetCollisions = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        HurtBox hurtBox = collision.GetComponent<HurtBox>();
        HitData hitData;
        
        if(collision.name == "Objects")
        {
            animator.CrossFade("Idle", 0.2f);
        }

        if (hurtBox != null && !colliders.Contains(collision))
        {
            if (hurtBox.active && hurtBox.owner.layer != 6)
            {
                colliders.Add(collision);
                hitData = new HitData
                {
                    damage = m_hitResponder == null ? 0 : m_hitResponder.damage,
                    hurtBox = hurtBox,
                    hitDetector = this
                };

                if (hitData.validate())
                {
                    hitData.hitDetector.hitResponder?.Response(hitData);
                    hitData.hurtBox.hurtResponder?.Response(hitData);
                }
            }
        }

    }
}
