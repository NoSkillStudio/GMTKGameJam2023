using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.Events;

public class ContextMenuChoice : MonoBehaviour
{
	private Image image;

	private bool canPress;

	[SerializeField] private UnityEvent OnPressed;
	
	private void Start()
	{
		image = GetComponent<Image>();

		canPress = false;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) && canPress)
		{
			OnPressed.Invoke();
			canPress = false;
			FindObjectOfType<PlayerController>().SetNormalSpeed();
			GetComponentInParent<App>().HideContextMenu();
		}
	}

	public void Enter()
	{
		image.DOColor(new Color(0.4793991f, 0.3060164f, 0.5283019f), 0.3f);
		canPress = true;
	}

	public void Exit()
	{
        image.DOColor(new Color(0.6980392f, 0.5450981f, 0.7411765f), 0.3f);
		canPress = false;
    }
}