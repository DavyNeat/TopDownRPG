using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour, HitDetector
{
    [SerializeField] private LayerMask m_layerMask;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform hitboxTransform;
    [SerializeField] private Vector2 size;
    private HitResponder m_hitResponder; 

    public HitResponder hitResponder { get => m_hitResponder; set => m_hitResponder = value; }

    void Start()
    {
        hitboxTransform = GetComponent<Transform>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.matrix = Matrix4x4.TRS((Vector2)hitboxTransform.position,
                        hitboxTransform.rotation,
                        size);
        Gizmos.DrawWireCube(Vector2.zero, size);
    }

    public void checkHit()
    {

        RaycastHit2D[] hits =
            Physics2D.BoxCastAll(
                hitboxTransform.position,
                size,
                playerTransform.eulerAngles.z,
                playerTransform.forward,
                0f);

        HurtBox hurtBox = null;
        HitData hitData = null;
        foreach (RaycastHit2D hit in hits)
        {
            print(hit.collider.gameObject.tag);
            hurtBox = hit.collider.GetComponent<HurtBox>();
            if (hurtBox != null)
                if (hurtBox.active)
                {
                    hitData = new HitData
                    {
                        damage = m_hitResponder == null ? 0 : m_hitResponder.damage,
                        hurtBox = hurtBox,
                        hitDetector = this                        
                    };

                    if (hitData.validate())
                    {
                        print("Validated");
                        hitData.hitDetector.hitResponder?.Response(hitData);
                        hitData.hurtBox.hurtResponder?.Response(hitData);
                    }
                }
        }
    }
}
