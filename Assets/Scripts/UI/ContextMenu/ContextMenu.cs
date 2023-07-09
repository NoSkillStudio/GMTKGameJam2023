using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ContextMenu : MonoBehaviour
{
    [SerializeField] private UnityEvent OnChosenOpen;
    [SerializeField] private ContextMenuChoice[] choices;

    private RectTransform rectTransform;
    [SerializeField] private Vector3 rightUpPos;
    [SerializeField] private Vector3 leftUpPos;
    [SerializeField] private Vector3 rightDownPos;
    [SerializeField] private Vector3 leftDownPos;

    [SerializeField] private App app;

    private int maxChoice;
    private int choice;
    private int previousChoice;

    private bool canSwitch;

    private void Start()
    {
        maxChoice = choices.Length - 1;
        choice = maxChoice;
        previousChoice = choice;
        rectTransform = GetComponent<RectTransform>();


        if (app.transform.position.x < 0 && app.transform.position.y < 0)
            rectTransform.localPosition = rightUpPos;
        if (app.transform.position.x < 0 && app.transform.position.y > 0)
        { 
            rectTransform.localPosition = rightDownPos;
            Debug.Log(app.transform.position);
        }    
        if (app.transform.position.x > 0 && app.transform.position.y > 0)
            rectTransform.localPosition = leftDownPos;
        if (app.transform.position.x > 0 && app.transform.position.y < 0)
            rectTransform.localPosition = leftUpPos;

    }

    private void OnEnable()
    {
        canSwitch = true;
        choices[choice].Enter();
    }

    private void OnDisable()
    {
        canSwitch = false;
    }

    private void Update()
    {


        if (Input.GetKeyDown(KeyCode.W))
            choice++;
        if (Input.GetKeyDown(KeyCode.S))
            choice--;

        if (choice <= 0)
            choice = 0;
        if (choice >= maxChoice)
            choice = maxChoice;

        if (previousChoice != choice)
        {
            choices[previousChoice].Exit();
            choices[choice].Enter();
            previousChoice = choice;
        }
    }

}