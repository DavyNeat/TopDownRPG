using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSystem : MonoBehaviour
{
    public int level;
    private int experienceToNextLevel;
    private int maxExperience;
    private StatsSystem statsSystem;

    void Start()
    {
        statsSystem = GetComponent<StatsSystem>();
        level = 1;
        maxExperience = 10;
        experienceToNextLevel = maxExperience;
    }

    void addExperience(int experience)
    {
        if (experience < experienceToNextLevel)
        {
            experienceToNextLevel -= experience;
            return;
        }

        while (experience >= experienceToNextLevel)
        {
            experience -= experienceToNextLevel;
            level++;
            statsSystem.addPoints(3);
            maxExperience = level * (int) (Mathf.Log10(level) / Mathf.Log10(2)) + 10;
            experienceToNextLevel = maxExperience;
        }

        experienceToNextLevel -= experience;
    }

    public float getPercentToNextLevel()
    {
        return 1.0f - ((float)experienceToNextLevel / (float)maxExperience);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ExperienceOrb" && this.tag == "Player")
        {
            addExperience(10);
            Destroy(collision.gameObject);
        }
    }
}
