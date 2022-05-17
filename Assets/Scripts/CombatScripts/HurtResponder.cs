using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HurtResponder
{
    public bool checkHit(HitData data);
    public void Response(HitData data);
}
