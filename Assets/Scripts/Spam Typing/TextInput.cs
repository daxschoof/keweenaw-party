using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;


public class TextInput : MonoBehaviour
{
    public String txt;

    public Text time ;
    public GameObject inputFeild;
    public GameObject inputFieldObject;
    public GameObject targetText;
    private int _numWord = 0;
    public GameObject scoreDisplay;
    private int _score = 0;
    private float _timer = 6;
    private int _numPlayed = 0;
    private int updates = 0;
    public GameObject endText;
    public GameObject MainMenu;
    public GameObject replayButton;
    private InputField inputField;
    protected string [] targetWords = {
        "Test","Husky","Hockey","Broomball","Sauna","Snow","Wear a hat","Rehki","MEEM","Wads dinner",
        "DHH","Mcnair","programing","finals","Snowstorm","College of Computing"
    };

    private int[] usedIndex = null;
    private int usedIndexIndex = 0;


    public void Start()
    {
      targetText.GetComponent<Text>().text = targetWords[Random.Range(0,3)];
        inputField = inputFieldObject.GetComponent<InputField>();
        inputField.ActivateInputField(); //Re-focus on the input field
        inputField.Select();//Re-focus on the input field
        endText.gameObject.SetActive(false);
      MainMenu.gameObject.SetActive(false);
      replayButton.gameObject.SetActive(false);
    }
    private void Update()
    {
      updates++;
      _timer = _timer - Time.deltaTime;
      if(updates > 25)
      {
        time.GetComponent<Text>().text = " " + _timer;
        updates = 0;
      }
      if(Input.GetKeyDown(KeyCode.Return))
      {
            inputField.ActivateInputField(); //Re-focus on the input field
            inputField.Select();//Re-focus on the input field
            updateText();
        ;
        }
      if(_timer < 0)
      {
        _timer = 5;

        updateText();
        if(_numPlayed > 3)
        {
          endText.GetComponent<Text>().text = "You played spam typing and got a score of  " +_score;
          endText.gameObject.SetActive(true);
          MainMenu.gameObject.SetActive(true);
          inputFeild.gameObject.SetActive(false);
          scoreDisplay.gameObject.SetActive(false);
          targetText.gameObject.SetActive(false);
          replayButton.gameObject.SetActive(true);
          time.gameObject.SetActive(false);

          print("congrats you at the end of the game!!!");
        }
      }
    }
    public void updateText()
    {
        _numPlayed++;
        if (usedIndex == null)
        {
            usedIndex = new int[targetWords.Length];
        }

        usedIndex[usedIndexIndex] = _numWord;
        usedIndexIndex++;
        txt = inputFeild.GetComponent<Text>().text;


        if (txt.Equals(targetText.GetComponent<Text>().text))
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

        inputField.text = "";

    }
public void mainMenuSwitch()
{
  SceneManager.LoadScene(0);
}
public void replay()
{
  inputFeild.gameObject.SetActive(true);
  scoreDisplay.gameObject.SetActive(true);
  targetText.gameObject.SetActive(true);
  targetText.GetComponent<Text>().text = targetWords[Random.Range(0,3)];
    inputField = inputFieldObject.GetComponent<InputField>();
    inputField.ActivateInputField(); //Re-focus on the input field
    inputField.Select();//Re-focus on the input field
    endText.gameObject.SetActive(false);
  MainMenu.gameObject.SetActive(false);
  replayButton.gameObject.SetActive(false);
  time.gameObject.SetActive(true);
  usedIndexIndex = 0;
  usedIndex = null;
  _numPlayed = 0;
  _numWord= Random.Range(0, targetWords.Length);
  _timer = 5;
}
}
