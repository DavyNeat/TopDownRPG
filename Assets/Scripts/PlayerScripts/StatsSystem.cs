using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsSystem : MonoBehaviour
{
    [SerializeField] private int atkSpd;
    [SerializeField] private Text pointsText;
    public Dictionary<string, int> stats;
    private Dictionary<string, int> oldStats;
    private int statPoints;
    void Start()
    {
        stats = new Dictionary<string, int>();
        atkSpd = 0;
        statPoints = 0;
    }

    private void Update()
    {
        pointsText.text = "Stat Points: " + statPoints.ToString();
    }

    public void addPoints(int points)
    {
        if(points > 0)
            statPoints += points;
        print(statPoints);
    }

    public void updateStats()
    {

    }

}
