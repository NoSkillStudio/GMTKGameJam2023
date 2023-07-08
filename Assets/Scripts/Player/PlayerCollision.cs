using UnityEngine;
using UnityEngine.Events;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private UnityEvent OnCollidedApp;
    private App currentApp;
    private Vector3 offset = Vector3.zero;

    private void Start()
    {
        if (currentApp != null)
        {
            currentApp.transform.position = transform.position + offset;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out App app))
        {
            currentApp = app;
            offset = transform.position - currentApp.transform.position;

            OnCollidedApp.Invoke();
        }
    }

    public void OpenApp()
    { 
        currentApp.Open();
    }
}
