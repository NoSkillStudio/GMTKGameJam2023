using UnityEngine;

public class WindowSpawner : MonoBehaviour
{
    public enum Window
    {
        Explorer = 0,
        Browser = 1
    }

    [SerializeField] private GameObject[] windows;
    private GameObject openedWindows;
    private bool[] isSpawned = {false, false};
    private int totalWindows = 0;
    private Charge charge;

    private void Start()
    {
        openedWindows = GameObject.FindWithTag("OpenedWindows");
        charge = FindObjectOfType<Charge>();
    }

    private void Update()
    {
        if (totalWindows != 0)
        {
            charge.Power -= (0.00002f * totalWindows);
        }
    }

    public void OpenWindow(Window window)
    {
        int idx = (int) window;
        if (isSpawned[idx]) return;
        isSpawned[idx] = true;

        // Spawn window
        GameObject window_ = Instantiate(windows[idx], openedWindows.transform);
        totalWindows += 1;
    }

    public void SetIsSpawned(Window window, bool isSpawned)
    {
        this.isSpawned[(int) window] = isSpawned;

        if(!this.isSpawned[(int) window])
            totalWindows -= 1;
    }
}
