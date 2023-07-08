using UnityEngine;
using UnityEngine.Events;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private UnityEvent OnCollidedApp;

    private App currentApp;


    private void Start()
    {

    }

    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out App app))
        {
            currentApp = collision.gameObject.GetComponent<App>();
            currentApp.transform.SetParent(transform, true);

            OnCollidedApp.Invoke();
        }
    }

    public void OpenApp()
    { 
        currentApp.Open();
    }
}