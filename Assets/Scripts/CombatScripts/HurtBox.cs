using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HurtBox
{
    public bool active { get; }
    public GameObject owner { get; }
    public Transform transform { get; }
    public HurtResponder hurtResponder { get; set; }
    public bool checkHit(HitData data);
}
