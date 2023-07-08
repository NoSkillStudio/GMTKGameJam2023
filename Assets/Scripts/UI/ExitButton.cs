using UnityEngine;
using UnityEngine.Events;

public class ExitButton : MonoBehaviour
{
	[SerializeField] private UnityEvent OnExit;

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
			OnExit.Invoke();
	}

	public void Exit()
	{
		OnExit.Invoke();
	}
}