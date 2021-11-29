using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
	public Text time ;

	private void Start()
	{
		time = GetComponent<Text>();

	}

	void Update()
    {		
		string s = String.Format("11:59:{0} PM", Mathf.Round(Time.time).ToString().PadLeft(2, '0') );
        time.text = s;
    }
}
