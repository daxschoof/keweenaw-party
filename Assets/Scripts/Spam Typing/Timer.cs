using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
	private Text time;
	private float timeRemaining = 5;

	private void Start()
	{
		time = GameObject.Find("Timer").GetComponent<Text>();
		Time.timeScale = 1;
	}

    void Update()
    {
		if (timeRemaining > 0)
		{
			timeRemaining -= Time.deltaTime;
			DisplayTime(timeRemaining);
		}
		else
		{
			timeRemaining = 5;
			DisplayTime(timeRemaining);
		}
	}


	void DisplayTime(float timeToDisplay)
	{
		int intTime = (int)timeToDisplay;
		int minutes = intTime / 60;
		int seconds = intTime % 60;
		float fraction = timeToDisplay * 1000;
		fraction = (fraction % 1000);

		time.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, fraction);
	}
}
