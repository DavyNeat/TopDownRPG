using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsSystem : MonoBehaviour
{
    [SerializeField] private Text pointsText;
    private PlayerAttack attack;
    private PlayerMovement playerMovement;
    private PlayerStatus status;
    public Dictionary<string, int> newStats = new Dictionary<string, int>();
    private Dictionary<string, int> currStats;
    public int currStatPoints;
    public int prevStatPoints;
    void Start()
    {
        currStatPoints = 0;
        attack = GetComponentInChildren<PlayerAttack>();
        playerMovement = GetComponentInChildren<PlayerMovement>();
        status = GetComponentInChildren<PlayerStatus>();
    }

    private void Update()
    {
        pointsText.text = $"Stat Points: {currStatPoints}";
    }

    public void addPoints(int points)
    {
        if (points > 0)
        {
            currStatPoints += points;
            prevStatPoints += points;
        }
        
    }

    public void updateStats(string[] statNames, int[] statPoints)
    {
        currStats = newStats;
        newStats = new Dictionary<string, int>();
        int pointDifference;
        for (int i = 0; i < statNames.Length; i++)
        {
            newStats.Add(statNames[i], statPoints[i]);
            pointDifference = newStats[statNames[i]] - currStats[statNames[i]];

            switch (statNames[i])
            {
                case "Speed":
                    playerMovement.updateSpeed(newStats["Speed"]);
                    break;

                case "Dexterity":
                    attack.upgradeAttackSpeed(newStats["Dexterity"]);
                    break;

                case "Strength":
                    attack.upgradeBaseDamage(pointDifference);
                    break;

                case "Vitality":
                    status.upgradeHealth(pointDifference);
                    break;
            }

        }

    }

}
