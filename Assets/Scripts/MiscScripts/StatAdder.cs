using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatAdder : MonoBehaviour
{
    [SerializeField] private StatsSystem statsSystem;
    private Text statValue;
    public int currStatAmount;
    private int prevStatAmount;
    private Button[] statChangeButtons;
    private Button increasePoints;
    private Button decreasePoints;
    void Start()
    {
        print(name);
        statValue = GetComponentInChildren<Text>();
        foreach(Button button in GetComponentsInChildren<Button>())
        {
            print(button.name);
            if(button.name == "IncreasePoints")
                increasePoints = button;
            else
                decreasePoints = button;
        }
        increasePoints.onClick.AddListener(increaseStat);
        decreasePoints.onClick.AddListener(decreaseStat);
        currStatAmount = 0;
        prevStatAmount = currStatAmount;
        statValue.text = $"{currStatAmount}";
        statsSystem.newStats.Add($"{name}", 0);
    }

    private void Update()
    {
        statValue.text = $"{currStatAmount}";
        //print(decreasePoints.gameObject.name);
        //print(increasePoints.gameObject.name);
        if (currStatAmount == prevStatAmount)
            decreasePoints.gameObject.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
        else
            decreasePoints.gameObject.GetComponent<Image>().color = new Color32(150, 0, 0, 255);

        if (statsSystem.currStatPoints > 0)
            increasePoints.gameObject.GetComponent<Image>().color = new Color32(30, 200, 30, 255);
        else
            increasePoints.gameObject.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
    }

    void increaseStat()
    {
        if (statsSystem.currStatPoints > 0)
        {
            currStatAmount++;
            statsSystem.currStatPoints--;
        }
    }

    void decreaseStat()
    {
        if (currStatAmount > prevStatAmount)
        {
            currStatAmount--;
            statsSystem.currStatPoints++;
        }
    }

    public void updateStatValues()
    {
        prevStatAmount = currStatAmount; 
    }

}
