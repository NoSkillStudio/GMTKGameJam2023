using UnityEngine;
using UnityEngine.Events;

public class DesktopIcon : MonoBehaviour
{
    [SerializeField] UnityEvent onEnter;
    [SerializeField] UnityEvent onStay;
    [SerializeField] UnityEvent onExit;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        onEnter?.Invoke();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        onEnter?.Invoke();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        onExit?.Invoke();
    }
}
