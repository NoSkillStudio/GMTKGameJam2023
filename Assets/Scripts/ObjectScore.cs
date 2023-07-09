using System;
using UnityEngine;

public class ObjectScore : MonoBehaviour
{
    public static event Action<int> OnChanged;

    [SerializeField] private int score;

    public void Activate()
    {
        OnChanged?.Invoke(score);
    }
}