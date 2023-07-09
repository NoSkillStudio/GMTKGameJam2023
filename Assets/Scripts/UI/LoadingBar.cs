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
	private CursorStateManager manager;

	private void Start()
	{
		image = GetComponent<Image>();
	}

	private void Update()
	{
		image.fillAmount += 0.0001f;
		if (image.fillAmount == 1)
		{
            GetComponent<ObjectScore>().Activate();
            OnEnd.Invoke();
            manager = FindObjectOfType<CursorStateManager>();
            manager.SwitchToState(ScriptableObject.CreateInstance<CursorAgroState>());
            Destroy(gameObject);
		}
	}
}