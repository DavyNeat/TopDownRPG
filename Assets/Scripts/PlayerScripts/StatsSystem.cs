using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsSystem : MonoBehaviour
{
    public int statPoints;
    void Start()
    {
        statPoints = 0;
    }

    public void addPoints(int points)
    {
        if(points > 0)
            statPoints += points;
        print(statPoints);
    }
}
