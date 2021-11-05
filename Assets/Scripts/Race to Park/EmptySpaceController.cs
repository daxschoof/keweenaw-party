using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptySpaceController : MonoBehaviour
{
    private RaceToParkMain main;

    void Start()
    {
        main = GameObject.Find("Main Camera").GetComponent<RaceToParkMain>();
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "Human Player")
        {
            main.isParked = true;
        }
            
    }
}
