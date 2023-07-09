using Unity.VisualScripting;
using UnityEngine;

public class WindowSpawner : MonoBehaviour
{
    public enum Window
    {
        Explorer,
        Browser,
        MyCat,
        vNovell,
        Matryoshka,
        Cards,
        EyeHorror
    }

    [SerializeField] private GameObject[] windows;
    public GameObject[] Windows
    {
        get
        {
            return windows;
        }
    }
    private GameObject openedWindows;
    private bool[] isSpawned = {false, false, false, false, false, false };
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
        Debug.Log((int)window);
        int idx = (int) window;
        if (isSpawned[idx]) return;
        isSpawned[idx] = true;

        // Spawn window
        GameObject window_ = Instantiate(windows[idx], openedWindows.transform);
        try
        {
            window_.GetComponent<AppWindow>().Window = window;
        }
        catch 
        {
            Debug.Log("It is Explorer");
        }
        totalWindows += 1;
    }

    public void SetIsSpawned(Window window, bool isSpawned)
    {
        this.isSpawned[(int) window] = isSpawned;

        if(!this.isSpawned[(int) window])
            totalWindows -= 1;
    }
}
