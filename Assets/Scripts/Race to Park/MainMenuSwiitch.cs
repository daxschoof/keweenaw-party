using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuSwiitch : MonoBehaviour
{
    public void switchScene(int num)
    {
        SceneManager.LoadScene(num);
    }
}
