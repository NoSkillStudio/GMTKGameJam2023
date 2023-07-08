using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowSpawner : MonoBehaviour
{
    public enum Window
    {
        Explorer = 0,
        Browser = 1
    }

    [SerializeField] private GameObject[] windows;
    [SerializeField] private GameObject[] icons;
    private Canvas canvas;
    private GameObject taskbar;
    private GameObject openedWindows;

    private void Start()
    {
        canvas = FindObjectOfType<Canvas>();
        taskbar = GameObject.FindWithTag("Windows");
        openedWindows = GameObject.FindWithTag("OpenedWindows");
        OpenWindow(Window.Explorer);
    }

    public void OpenWindow(Window window)
    {
        int idx = (int) window;
        // Add icon to taskbar
        GameObject icon = Instantiate(icons[idx], taskbar.transform);
        // icon.transform.localScale = new Vector3(40, 40, 1);
        // Spawn window
        GameObject window_ = Instantiate(windows[idx], openedWindows.transform);
    }
}
