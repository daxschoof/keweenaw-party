using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class goal : MonoBehaviour
{
   

    void OnTriggerEnter2D ()
    {
        Debug.Log("You Won!");
        Time.timeScale = 0;
        SceneManager.LoadScene(0);
    }

   
}
