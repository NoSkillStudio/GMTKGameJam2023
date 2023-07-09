using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AppWindow : MonoBehaviour
{
    public WindowSpawner.Window Window { get => window; set => window = value; }
    [SerializeField] private WindowSpawner.Window window;

	[SerializeField] private TMP_Text nameText;
	[SerializeField] Image icon;
	[SerializeField] Sprite[] icons;
    private void Start()
	{
		switch (window)
		{
			case WindowSpawner.Window.Browser:
				nameText.text = WindowSpawner.Window.Browser.ToString();
				icon.sprite = icons[(int) WindowSpawner.Window.Browser - 1];
                break;
			case WindowSpawner.Window.MyCat:
                nameText.text = WindowSpawner.Window.MyCat.ToString();
                icon.sprite = icons[(int)WindowSpawner.Window.MyCat - 1];
                break;
			case WindowSpawner.Window.vNovell:
                nameText.text = WindowSpawner.Window.vNovell.ToString();
                icon.sprite = icons[(int)WindowSpawner.Window.vNovell - 1];
                break;
			case WindowSpawner.Window.Matryoshka:
                nameText.text = WindowSpawner.Window.Matryoshka.ToString();
                icon.sprite = icons[(int)WindowSpawner.Window.Matryoshka - 1];
                break;
			case WindowSpawner.Window.Cards:
                nameText.text = WindowSpawner.Window.Cards.ToString();
                icon.sprite = icons[(int)WindowSpawner.Window.Cards - 1];
                break;
			case WindowSpawner.Window.EyeHorror:
                nameText.text = WindowSpawner.Window.EyeHorror.ToString();
                icon.sprite = icons[(int)WindowSpawner.Window.EyeHorror - 1];
                break;
			default:
				break;
		}
	}

	private void Update()
	{
		
	}
}