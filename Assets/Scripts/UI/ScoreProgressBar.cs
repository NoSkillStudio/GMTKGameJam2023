using UnityEngine;
using UnityEngine.UI;

public class ScoreProgressBar : MonoBehaviour
{
    [SerializeField] private Image image;
	[SerializeField] private ScoreCollector scoreCollector;

	public void Change(int value)
	{
		image.fillAmount = value / scoreCollector.MaxScore;
	}
}