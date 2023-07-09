using UnityEngine;
using UnityEngine.Events;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private AudioSource grabSound;

    private CursorStateManager manager;
    public bool isGrabbed { get; private set; }
    private PlayerController player;
    private App currentApp;
    private float offset = 1.25f;
    private File currentFile;
    private Animator animator;

    [SerializeField] private UnityEvent OnTriggerEnterApp;
    [SerializeField] private UnityEvent OnTriggerExitApp;


    private void Start()
    {
        player = GetComponent<PlayerController>();
        manager = FindObjectOfType<CursorStateManager>();
        animator = GetComponent<Animator>();
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
        if (player.isStunned || isGrabbed) return;

        if (collision.gameObject.TryGetComponent(out App app))
        {
            currentApp = app;

            currentApp.ShowContextMenu();

            OnTriggerEnterApp?.Invoke();
        }

        if (collision.gameObject.TryGetComponent(out File file))
        {
            file.Select();
            currentFile = file;
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

        if (collision.gameObject.TryGetComponent(out File file))
        {
            file.DeSelect();
            currentFile = null;
        }
    }

    public void OpenApp()
    {
        currentApp.Open();
    }

    public void Grab()
    {
        animator.SetTrigger("Grab");
        grabSound.Play();
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
