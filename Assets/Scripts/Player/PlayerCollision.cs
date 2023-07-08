using UnityEngine;
using UnityEngine.Events;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private UnityEvent OnTriggerEnterApp;
    [SerializeField] private UnityEvent OnTriggerExitApp;
    private bool isGrabbed;
    private PlayerController player;
    private App currentApp;
    private float offset = 1.25f;
    private float x = 0f;

    private void Start()
    {
        player = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (isGrabbed)
        {
            if (player.spriteRenderer.flipX)
                currentApp.transform.position = transform.position - Vector3.right * offset;
            else
                currentApp.transform.position = transform.position + Vector3.right * offset;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out App app))
        {
            currentApp = app;

            currentApp.ShowContextMenu();

            OnTriggerEnterApp.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out App app))
        {
            currentApp.HideContextMenu();

            OnTriggerExitApp.Invoke();
        }
    }

    public void OpenApp()
    {
        currentApp.Open();
    }

    public void Grab()
    {
        isGrabbed = true;
    }
}
