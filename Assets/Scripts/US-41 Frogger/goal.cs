using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class goal : MonoBehaviour
{
	// Max amount of time while player can still achieve positive score
	public float maxTime;
	
	public GameObject endMenu;

	public GameObject resultText;
	
	public GameObject gameOverText;
	
	// Start is called before the first frame update
	private void Start()
	{
		maxTime = Time.time + 30f;
	}
	
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
            {
				if (endMenu.activeSelf)
				{
					Time.timeScale = 1;
					endMenu.SetActive(false);
				}
				else
				{
					resultText.GetComponent<Text>().text = "";
					gameOverText.GetComponent<Text>().text = "Paused";
					endMenu.SetActive(true);
					Time.timeScale = 0;
				}
            }
	}
	
    void OnTriggerEnter2D (Collider2D collider)
    {
		int score;
		
		
		if (collider.tag == "frog")
		{
			score = computeScore(Time.time);
		} 
		else
		{
			score = 0;
		}
		gameOverText.GetComponent<Text>().text = "Game Over";
		resultText.GetComponent<Text>().text = "Score: "+score;
		endMenu.SetActive(true);
        Time.timeScale = 0;
    }
	
	private int computeScore (float time)
	{
		time = maxTime - time;	
		time = (time > 0) ? (time * 33.33f) : 0f;
		return (int) Math.Round(time);
	}
	
	public void reloadGame() {
		Time.timeScale = 1;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
	
	public void loadMenu() {
		Time.timeScale = 1;
		SceneManager.LoadScene(0);
	}

}
