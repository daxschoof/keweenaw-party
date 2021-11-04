using UnityEngine;

public class goal : MonoBehaviour
{
    void OnTriggerEnter2D ()
    {
        Debug.Log("You Won!");
        Time.timeScale = 0;
    }
}
