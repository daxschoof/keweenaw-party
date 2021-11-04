using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void switchScene(int num)
    {
        print("clicked");
        SceneManager.LoadScene(num);
    }
}