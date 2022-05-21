using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HitDetector
{
    public HitResponder hitResponder { get; set; }
    //public void checkHit();
}
