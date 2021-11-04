using UnityEngine;
using System;

public class goal : MonoBehaviour
{
    void OnTriggerEnter2D ()
    {
        Debug.Log("You Won! Score:  "+computeScore(Time.time));
        Time.timeScale = 0;
    }
	
	int computeScore (float time)
	{
		time = 30f - time;	
		time = (time > 0) ? (time * 33.33f) : 0f;
		return (int) Math.Round(time);
	}
}
