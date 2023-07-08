using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.GraphicsBuffer;

public class App : MonoBehaviour
{
    [SerializeField] private UnityEvent OnOpen;
    public WindowSpawner.Window window { get; }
    private WindowSpawner spawner;

    [SerializeField] private GameObject contextMenu;

    private ObjectScore objectScore;

    [SerializeField] private UnityEvent OnDestroy;

    public Vector3 SpawnPoint { get => spawnPoint; }
    private Vector3 spawnPoint;

    private void Start()
    {
        spawner = FindObjectOfType<WindowSpawner>();
        objectScore = GetComponent<ObjectScore>();

        spawnPoint = transform.position;
        Debug.Log(spawnPoint);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Trash trash))
        {
            objectScore.Activate();
            OnDestroy.Invoke();
            FindObjectOfType<PlayerCollision>().DontGrab();
            Destroy(gameObject, 0.01f);
        }

        //if (collision.gameObject.TryGetComponent(out CursorStateManager cursor))
        //{
        //    //Debug.Log(transform.position);
        //    //Debug.Log(cursor.transform.position);
        //    Debug.Log(Vector3.Distance(transform.position, cursor.cursorTransform.position));
        //    if (Vector3.Distance(transform.position, cursor.cursorTransform.position) <= 0.75f)            
        //        transform.SetParent(cursor.gameObject.transform, true);
        //}
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out CursorStateManager cursor))
        {

        }
    }

    public void Open()
    {
        OnOpen?.Invoke();
        spawner.OpenWindow(window);
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
