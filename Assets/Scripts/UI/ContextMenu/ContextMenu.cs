using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ContextMenu : MonoBehaviour
{
    [SerializeField] private UnityEvent OnChosenOpen;
    [SerializeField] private ContextMenuChoice[] choices;

    private int maxChoice;
    private int choice;
    private int previousChoice;

    private bool canSwitch;

    private void Start()
    {
        maxChoice = choices.Length - 1;
        choice = maxChoice;
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
        if(Input.GetKeyDown(KeyCode.S))
            choice--;

        if (choice <= 0)
            choice = 0;
        if (choice >= maxChoice)
            choice = maxChoice;

        if (previousChoice != choice)
        {
            choices[previousChoice].Exit();
            choices[choice].Enter();
            Debug.Log("Enter");
            previousChoice = choice;
        }
    }

}