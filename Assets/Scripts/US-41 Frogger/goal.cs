using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class goal : MonoBehaviour
{
	public float maxTime;
	public GameObject endMenu;

	
	// Start is called before the first frame update
	private void Start()
	{
		maxTime = Time.time + 30f;
	}
	
    void OnTriggerEnter2D (Collider2D collider)
    {
		int score;
		
		
		if (collider.tag == "frog")
		{
			score = computeScore(Time.time);
			endMenu.SetActive(true);
		} 
		else
		{
			score = 0;
		}
	
		Debug.Log("Game ended. Score:  "+score);
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
