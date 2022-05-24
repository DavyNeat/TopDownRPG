using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    private Image staminaBar;
    private int level;
    [SerializeField] private PlayerStatus status;
    void Start()
    {
        staminaBar = GetComponent<Image>();
    }

    void Update()
    {
        staminaBar.fillAmount = Mathf.MoveTowards(staminaBar.fillAmount, status.percentStamina(), 0.5f * Time.deltaTime);
    }
}
