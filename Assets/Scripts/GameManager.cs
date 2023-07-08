using System;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private TMP_Text time;
    private System.Globalization.CultureInfo english = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");

    private void Start()
    {
        Cursor.visible = false;
        time = GameObject.FindWithTag("Time").GetComponent<TMP_Text>();
    }

    private void Update()
    {
        time.text = DateTime.Now.ToString("hh:mm:ss tt", english);
    }
}
