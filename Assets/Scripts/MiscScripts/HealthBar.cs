using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image healthBar;
    private int level;
    [SerializeField] private PlayerStatus status;
    void Start()
    {
        healthBar = GetComponent<Image>();
    }

    void Update()
    {
        healthBar.fillAmount = Mathf.MoveTowards(healthBar.fillAmount, status.percentHealth(), 0.5f * Time.deltaTime);
    }
}
