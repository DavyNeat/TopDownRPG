using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelSystem : MonoBehaviour
{
    public int level;
    private int experienceToNextLevel;
    private int maxExperience;

    void Start()
    {
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
            maxExperience = level * (int) (Mathf.Log10(level) / Mathf.Log10(2)) + 10;
            experienceToNextLevel = maxExperience;
        }

        experienceToNextLevel -= experience;
        print("level: " + level);
        print("experience to next level: " + experienceToNextLevel);
    }

    public int getExperienceToNextLevel()
    {
        return experienceToNextLevel;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        print("collision");
        if (collision.tag == "ExperienceOrb")
        {
            print("adding experience");
            addExperience(10);
            Destroy(collision.gameObject);
        }
    }
}
