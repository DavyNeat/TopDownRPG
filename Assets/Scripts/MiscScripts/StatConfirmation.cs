using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatConfirmation : MonoBehaviour
{
    private StatAdder[] statAdders;
    [SerializeField] private Button confirmButton;
    [SerializeField] private StatsSystem statsSystem;
    private string[] names;
    private int[] points;
    void Start()
    {
        statAdders = GetComponentsInChildren<StatAdder>();
        confirmButton.onClick.AddListener(confirmStats);
        names = new string[statAdders.Length];
        points = new int[statAdders.Length];
    }

    //updates the values that are held in the statsystem
    private void confirmStats()
    {
        for(int i = 0; i < statAdders.Length; i++)
        {
            statAdders[i].updateStatValues();
            names[i] = statAdders[i].name;
            points[i] = statAdders[i].currStatAmount;
        }
        statsSystem.updateStats(names, points);
    }
}
