using UnityEngine;
using UnityEngine.Events;

public class App : MonoBehaviour
{
    [SerializeField] private UnityEvent OnOpen;
    [SerializeField] private WindowSpawner.Window _window;
    public WindowSpawner.Window window
    {
        get
        {
            return _window;
        }
    }
    private WindowSpawner spawner;

    [SerializeField] private AudioSource trashSound;

    [SerializeField] private GameObject contextMenu;

    private ObjectScore objectScore;

    [SerializeField] private UnityEvent OnDestroy;

    public Vector3 SpawnPoint { get => spawnPoint; }
    private Vector3 spawnPoint;
    private PlayerCollision player ;


    private void Start()
    {
        spawner = FindObjectOfType<WindowSpawner>();
        objectScore = GetComponent<ObjectScore>();
        spawnPoint = transform.position;
        player = FindObjectOfType<PlayerCollision>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Trash trash))
        {
            trashSound.Play();
            objectScore?.Activate();
            OnDestroy?.Invoke();
            player.DontGrab();
            Destroy(gameObject, 0.01f);
        }
    }

    public void Open()
    {
        OnOpen?.Invoke();
        spawner.OpenWindow(_window);
    }

    public void ShowContextMenu()
    {
        contextMenu.SetActive(true);
    }

    public void HideContextMenu()
    {
        contextMenu.SetActive(false);
    }
}
