using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : MonoBehaviour, HitResponder
{
    public int damage => 10;
    [SerializeField] private Hitbox hitBox;
    [SerializeField] private bool attack;
    private RaycastHit2D[] hitObjs;

    public bool checkHit(HitData data)
    {
        return true;
    }

    public void Response(HitData data)
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        hitBox = GetComponent<Hitbox>();
        hitBox.hitResponder = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            hitBox.checkHit();
        }
    }
}
