using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class App : MonoBehaviour
{
	[SerializeField] private UnityEvent OnOpen;
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.TryGetComponent(out Basket basket))
		{ 
			Destroy(gameObject);
		}
	}

	public void Open()
	{ 
		OnOpen.Invoke();
	}
}