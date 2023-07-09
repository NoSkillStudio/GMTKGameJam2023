using UnityEngine;

public class Crack : MonoBehaviour
{
    [SerializeField] private GameObject endPanel;

    public void ShowEndPanel()
	{
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
		endPanel.SetActive(true);
	}
}
