using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundPlayer : MonoBehaviour
{
	[SerializeField] private AudioSource kryaSound;
	private float time = 0;
	private float timer;
	private void Start()
	{
        timer = Random.Range(3, 10);
    }

	private void Update()
	{
		time += Time.deltaTime;
		if (time >= timer)
		{
			kryaSound.Play();
			timer += Random.Range(3,10);
		}
	}
}