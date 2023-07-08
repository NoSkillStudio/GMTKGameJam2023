using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class App : MonoBehaviour
{
	[SerializeField] private UnityEvent OnOpen;
	[SerializeField] private WindowSpawner.Window window;
	private WindowSpawner spawner;

	[SerializeField] private GameObject contextMenu;

    private void Start()
    {
        spawner = FindObjectOfType<WindowSpawner>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.TryGetComponent(out Trash trash))
		{ 
			Destroy(gameObject);
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
