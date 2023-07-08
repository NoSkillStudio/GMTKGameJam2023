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
		image.DOColor(new Color(0.4622642f, 0.1718227f, 0.3876553f), 0.3f);
		canPress = true;
	}

	public void Exit()
	{
        image.DOColor(new Color(0.6705883f, 0.2431373f, 0.5607843f), 0.3f);
		canPress = false;
    }
}