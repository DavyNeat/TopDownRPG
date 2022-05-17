using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitData
{

    public int damage;
    public HurtBox hurtBox;
    public HitDetector hitDetector;

    public bool validate()
    {
        if (hurtBox != null)
            if (hurtBox.checkHit(this))
                if (hurtBox.hurtResponder == null || hurtBox.hurtResponder.checkHit(this))
                    if (hitDetector.hitResponder == null || hitDetector.hitResponder.checkHit(this))
                        return true;
        
        return false;
    }
}
