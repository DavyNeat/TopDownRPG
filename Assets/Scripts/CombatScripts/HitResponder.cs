using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HitResponder 
{
    int damage { get; }
    public bool checkHit(HitData data);
    public void Response(HitData data);

}
