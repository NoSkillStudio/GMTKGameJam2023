using UnityEngine;

public class File : MonoBehaviour
{
    private GameObject outline;
    public bool selected { get; private set; }

    private void Start()
    {
        outline = GetComponentInChildren<Selection>().gameObject;
        outline.SetActive(false);
    }

    public void Select()
    {
        outline.SetActive(true);
        selected = true;
    }

    public void DeSelect()
    {
        outline.SetActive(false);
        selected = false;
    }
}
