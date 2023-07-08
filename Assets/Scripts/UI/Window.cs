using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    private void OnEnable()
    {
        transform.SetParent(null, true);
        transform.position = Vector2.zero;
    }
}