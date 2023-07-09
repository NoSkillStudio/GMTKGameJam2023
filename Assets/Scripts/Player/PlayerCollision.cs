using UnityEngine;
using UnityEngine.Events;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private UnityEvent OnTriggerEnterApp;
    [SerializeField] private UnityEvent OnTriggerExitApp;
    private CursorStateManager manager;
    public bool isGrabbed { get; private set; }
    private PlayerController player;
    private App currentApp;
    private float offset = 1.25f;

    private void Start()
    {
        player = GetComponent<PlayerController>();
        manager = FindObjectOfType<CursorStateManager>();
    }

    private void Update()
    {
        try
        {
            if (isGrabbed)
            {
                if (player.spriteRenderer.flipX)
                    currentApp.transform.position = transform.position - Vector3.right * offset;
                else
                    currentApp.transform.position = transform.position + Vector3.right * offset;
            }
        }
        catch (MissingReferenceException)
        {
            // утка выбросила в корзину приложение
            DontGrab();
            manager.SwitchToState(ScriptableObject.CreateInstance<CursorAgroState>());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!player.isStunned &&
            collision.gameObject.TryGetComponent(out App app) &&
            isGrabbed == false)
        {
            currentApp = app;

            currentApp.ShowContextMenu();

            OnTriggerEnterApp?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out App app))
        {
            try
            {
                currentApp.HideContextMenu();
                OnTriggerExitApp?.Invoke();
            }
            catch {}
        }
    }

    public void OpenApp()
    {
        currentApp.Open();
    }

    public void Grab()
    {
        manager.SwitchToState(ScriptableObject.CreateInstance<CursorAgroState>());
        isGrabbed = true;
    }

    public void DontGrab()
    {
        try
        {
            currentApp.HideContextMenu();
        }
        catch {}
        isGrabbed = false;
        currentApp = null;
    }
}
