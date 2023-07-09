using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LoadingBar : MonoBehaviour
{
	[SerializeField] private UnityEvent OnEnd;
	private Image image;
	private void Start()
	{
		image = GetComponent<Image>();
	}

	private void Update()
	{
		image.fillAmount += 0.0001f;
		if(image.fillAmount == 1)
			OnEnd.Invoke();
	}
}