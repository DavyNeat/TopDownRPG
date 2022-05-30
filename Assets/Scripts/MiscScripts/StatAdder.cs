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
        statValue = GetComponentInChildren<Text>();
        foreach(Button button in GetComponentsInChildren<Button>())
        {
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
            if (Input.GetKey(KeyCode.LeftShift))
            {
                int increaseAmount;
                int leftOver = statsSystem.currStatPoints - 10;
                if (leftOver < 0)
                    increaseAmount = statsSystem.currStatPoints;
                else
                    increaseAmount = 10;

                currStatAmount += increaseAmount;
                statsSystem.currStatPoints -= increaseAmount;
            }
            else
            {
                currStatAmount++;
                statsSystem.currStatPoints--;
            }
        }
    }

    void decreaseStat()
    {
        if (currStatAmount > prevStatAmount)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                int DecreaseAmount;
                int leftOver = currStatAmount - 10;
                if (leftOver < 0)
                    DecreaseAmount = statsSystem.currStatPoints;
                else
                    DecreaseAmount = 10;

                currStatAmount -= DecreaseAmount;
                statsSystem.currStatPoints += DecreaseAmount;
            }
            else
            {
                currStatAmount--;
                statsSystem.currStatPoints++;
            }
        }
    }

    public void updateStatValues()
    {
        prevStatAmount = currStatAmount; 
    }

}
