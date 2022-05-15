using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceBar : MonoBehaviour
{
    private Image ExpBar;
    private int level;
    public Text levelText;
    public LevelSystem levelSystem;
    void Start()
    {
        level = 1;
        ExpBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

        if (level == levelSystem.level)
        {
            ExpBar.fillAmount = Mathf.MoveTowards(ExpBar.fillAmount, levelSystem.getPercentToNextLevel(), 0.5f * Time.deltaTime);
            return;
        }

        if (ExpBar.fillAmount == 1.0f)
        {
            level++;
            levelText.text = level.ToString();
            ExpBar.fillAmount = 0.0f;
            return;
        }

        ExpBar.fillAmount = Mathf.MoveTowards(ExpBar.fillAmount, 1.0f, 0.5f * Time.deltaTime);
    }
}
