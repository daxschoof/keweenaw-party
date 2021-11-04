using UnityEngine;
using System;

public class goal : MonoBehaviour
{
	public float maxTime = 30f;
	
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
	
		Debug.Log("Game ended. Score:  "+score);
        Time.timeScale = 0;
    }
	
	int computeScore (float time)
	{
		time = maxTime - time;	
		time = (time > 0) ? (time * 33.33f) : 0f;
		return (int) Math.Round(time);
	}
}