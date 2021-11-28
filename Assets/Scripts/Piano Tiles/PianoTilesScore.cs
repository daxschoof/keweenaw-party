using UnityEngine;
using UnityEngine.UI;

public class PianoTilesScore : MonoBehaviour
{
    public static int scoreValue = 0;
    Text score;

    // Update is called once per frame
    void Start()
    {
        // Get the current score text
        score = GetComponent<Text> ();
    }

    void Update()
    {
        // UPdate text with scoreValue
        score.text = "Score: " + scoreValue;
    }
}
