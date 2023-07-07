using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class E : MonoBehaviour
{
    private bool canPressE;

    [SerializeField] private UnityEvent OnPressE;
    private void OnEnable()
    {
        canPressE = true;
    }

    private void OnDisable()
    {
        canPressE = false;
    }

    private void Update()
    {
        if(canPressE && Input.GetKeyDown(KeyCode.E))
        {
            OnPressE.Invoke();
            Debug.Log("E");
        }
    }
}