using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuAnimator : MonoBehaviour
{
    private Animator menuAnimator;
    private CanvasGroup canvasGroup;
    public bool menuShowing;
    private string currentState;
    [SerializeField] private Button menuButton;
    [SerializeField] private Button exitButton;
    void Start()
    {
        menuShowing = false;
        menuAnimator = GetComponent<Animator>();
        menuButton.onClick.AddListener(enterMenu);
        exitButton.onClick.AddListener(exitMenu);
    }

    void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;

        menuAnimator.Play(newState);
        currentState = newState;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            menuShowing = !menuShowing;


        if (menuShowing == false)
        {
            ChangeAnimationState("menu_hidden");
        }
        else
        {
            ChangeAnimationState("menu_showing");
        }
        
    }

    void enterMenu()
    {
        menuShowing = true;
    }

    void exitMenu()
    {
        menuShowing = false;
    }
}
