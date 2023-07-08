using UnityEngine;
using UnityEngine.Events;

public class App : MonoBehaviour
{
	[SerializeField] private UnityEvent OnOpen;
	public WindowSpawner.Window window { get; }
	private WindowSpawner spawner;

	[SerializeField] private GameObject contextMenu;

    private ObjectScore objectScore;

	[SerializeField] private UnityEvent OnDestroy;

    private void Start()
    {
        spawner = FindObjectOfType<WindowSpawner>();
        objectScore = GetComponent<ObjectScore>();
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
