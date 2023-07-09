using UnityEngine;

public class WindowSpawner : MonoBehaviour
{
    public enum Window
    {
        Explorer = 0,
        Browser = 1
    }

    [SerializeField] private GameObject[] windows;
    private Canvas canvas;
    private GameObject openedWindows;
    private bool[] isSpawned = {false, false};

    private void Start()
    {
        canvas = FindObjectOfType<Canvas>();
        openedWindows = GameObject.FindWithTag("OpenedWindows");
    }

    public void OpenWindow(Window window)
    {
        int idx = (int) window;
        if (isSpawned[idx]) return;
        isSpawned[idx] = true;

        // Spawn window
        GameObject window_ = Instantiate(windows[idx], openedWindows.transform);
    }

    public void SetIsSpawned(Window window, bool isSpawned)
    {
        this.isSpawned[(int) window] = isSpawned;
    }
}
