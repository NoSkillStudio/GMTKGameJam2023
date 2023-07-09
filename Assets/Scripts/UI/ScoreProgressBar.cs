using UnityEngine;
using UnityEngine.UI;

public class ScoreProgressBar : MonoBehaviour
{
    [SerializeField] private Image image;
	[SerializeField] private ScoreCollector scoreCollector;

	public void Change(int value)
	{
		if (value >= scoreCollector.MaxScore)
		{
			image.fillAmount = 1f;
			StopGame();
			return;
		}
		image.fillAmount = value / ((float) scoreCollector.MaxScore);
	}

	private void StopGame()
	{
		// stop game
		FindObjectOfType<PlayerController>().StopSpeed();
		FindObjectOfType<CursorStateManager>().SwitchToState(ScriptableObject.CreateInstance<CursorStopState>());
		// start animation
		FindObjectOfType<Crack>().GetComponent<Animator>().SetTrigger("Crack");
	}
}