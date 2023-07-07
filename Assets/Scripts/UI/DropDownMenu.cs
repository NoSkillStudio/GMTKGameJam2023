using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DropDownMenu : MonoBehaviour
{
    [SerializeField] private UnityEvent OnChosenOpen;

    public void SetChoice(int value)
    {
        switch (value)
        {
            case 0:
                OnChosenOpen.Invoke();
                break;
            case 1:
                Debug.Log(1);
                break;              
        }
    }


}