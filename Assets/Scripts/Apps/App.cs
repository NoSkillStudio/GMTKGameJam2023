using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class App : MonoBehaviour
{
	private void Start()
	{
		
	}

	private void Update()
	{
		
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.TryGetComponent(out Basket basket))
		{ 
			Destroy(gameObject);
		}
	}
}