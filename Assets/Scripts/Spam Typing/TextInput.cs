using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class TextInput : MonoBehaviour
{
    public String txt;
    public GameObject text;
    public GameObject inputFeild;
    public GameObject targetText;
    private int _numWord = 0;
    public GameObject scoreDisplay;
    private int _score = 0;
    protected string [] targetWords = {
        "Test","Husky","Hockey","Broomball","Sauna","Snow","Wear a hat","Rehki","MEEM","Wads dinner",
        "DHH","Mcnair","programing","finals","Snowstorm","College of Computing"
    };

    private int[] usedIndex = null;
    private int usedIndexIndex = 0;

    public void Start()
    {
        targetText.GetComponent<Text>().text = targetWords[0];
    }

    public void updateText()
    {
        if (usedIndex == null)
        {
            usedIndex = new int[targetWords.Length];
        }
       
        usedIndex[usedIndexIndex] = _numWord;
        usedIndexIndex++;
        txt = inputFeild.GetComponent<Text>().text;
       

        if (txt.Equals(targetWords[_numWord]))
        {
            _score++;
            scoreDisplay.GetComponent<Text>().text = "Score = " + _score;
        }
        else
        {
            print("this was incorrect + "+ targetWords[_numWord]);
        }

        //_numWord;
        _numWord= Random.Range(0, targetWords.Length);
        
        for (int i = 0; i < usedIndexIndex; i++)
        {
            if (usedIndex[i] == _numWord)
            {
                _numWord= Random.Range(0, targetWords.Length);
                i = 0;
            }
        }
        if (_numWord < targetWords.Length)
        {
            targetText.GetComponent<Text>().text = targetWords[_numWord];
        }

        text.GetComponent<Text>().text = txt;
        text.GetComponent<Text>().fontSize = 40;
        
    }
    
}
