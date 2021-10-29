using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
	public static GameController instance;

	public bool snowy;
	public bool joystick;
	public GameObject hudContainer;
	public Text timeCounter, countdownText;
	public bool gamePlaying { get; private set; }
	public int countdownTime;

	private float startTime, elapsedTime;
	TimeSpan timePlaying;

	private void Awake()
    {
		instance = this;
    }
	// Start is called before the first frame update
	private void Start()
	{
		gamePlaying = false;

		StartCoroutine(CountdownToStart());
	}

	private void BeginGame()
    {
		gamePlaying = true;
		startTime = Time.time;
    }

	private void Update()
    {
		if (gamePlaying)
        {
			elapsedTime = Time.time - startTime;
			timePlaying = TimeSpan.FromSeconds(elapsedTime);

			string timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss'.'ff");
        }
    }

	IEnumerator CountdownToStart()
    {
		while (countdownTime > 0)
        {
			countdownText.text = countdownTime.ToString();
			yield return new WaitForSeconds(1f);
			countdownTime--;
        }

		BeginGame();
		countdownText.text = "GO!";

		yield return new WaitForSeconds(1f);

		countdownText.gameObject.SetActive(false);
    }

}
