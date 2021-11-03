using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaceToParkMain : MonoBehaviour {
	public bool snowy;
	public bool joystick;
	public bool gamePlaying;
	public float timeRemaining = 30;
	private int countdownTime = 3;
	private Text countdown, gameCountdown;
	private float startTime, elapsedTime, timeLeft;
	public GameObject endMenu;

	// Start is called before the first frame update
	private void Start() {
		gamePlaying = false;
		countdown = GameObject.Find("Countdown Text").GetComponent<Text>();
		gameCountdown = GameObject.Find("GameCountdownText").GetComponent<Text>();
		countdown.gameObject.SetActive(true);
		gameCountdown.gameObject.SetActive(true);
		endMenu.gameObject.SetActive(false);
		StartCoroutine(StartCountdown());
	}

	private void Update() {
		if(gamePlaying) {
			if (timeRemaining > 0)
            {
				timeRemaining -= Time.deltaTime;
				DisplayTime(timeRemaining);
            }
            else
            {
				timeRemaining = 0;
				DisplayTime(timeRemaining);
				gamePlaying = false;
				endMenu.gameObject.SetActive(true);
			}
		}
	}

	IEnumerator StartCountdown() {
		while(countdownTime > 0) {
			countdown.text = countdownTime.ToString();
			yield return new WaitForSeconds(1f);
			countdownTime--;
		}
		gamePlaying = true;
		countdown.text = "GO!";
		yield return new WaitForSeconds(1f);
		gamePlaying = true;
		countdown.gameObject.SetActive(false);
	}

	void DisplayTime(float timeToDisplay)
    {
		int intTime = (int)timeToDisplay;
		int minutes = intTime / 60;
		int seconds = intTime % 60;
		float fraction = timeToDisplay * 1000;
		fraction = (fraction % 1000);

		gameCountdown.text = string.Format("Time left: {0:00}:{1:00}:{2:000}", minutes, seconds, fraction);
	}
}
