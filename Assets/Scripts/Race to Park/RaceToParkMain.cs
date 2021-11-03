using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaceToParkMain : MonoBehaviour {
	public bool snowy;
	public bool joystick;
	public bool gamePlaying;
	public TimeSpan timePlaying;
	private int countdownTime = 3;
	private Text countdown, timeCounter;
	private float startTime, elapsedTime;

	// Start is called before the first frame update
	private void Start() {
		gamePlaying = false;
		countdown = GameObject.Find("Countdown Text").GetComponent<Text>();
		countdown.gameObject.SetActive(true);
		StartCoroutine(Countdown());
	}

	private void Update() {
		if(gamePlaying) {
			elapsedTime = Time.time-startTime;
			timePlaying = TimeSpan.FromSeconds(elapsedTime);
			string timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss'.'ff");
		}
	}

	IEnumerator Countdown() {
		while(countdownTime > 0) {
			countdown.text = countdownTime.ToString();
			yield return new WaitForSeconds(1f);
			countdownTime--;
		}
		gamePlaying = true;
		countdown.text = "GO!";
		yield return new WaitForSeconds(1f);
		gamePlaying = true;
		startTime = Time.time;
		countdown.gameObject.SetActive(false);
	}
}
