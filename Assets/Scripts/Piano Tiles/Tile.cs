using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tile : MonoBehaviour
{
	public Rigidbody2D Rb;

	public float minSpeed = 8f;
	public float maxSpeed = 12f;
	public float tileSpeed = 10f;
	public SpriteRenderer color;

	void Start()
	{

	}

	void Update()
    {
		// Check if the A key has been pressed at the right time
		if (Input.GetKeyDown(KeyCode.A) & Rb.transform.position.y < -2 & Rb.transform.position.y > -6 & Rb.transform.position.x > -3 & Rb.transform.position.x < -1.5)
		{
			// Change the tile color
			color.color = Color.yellow;
			// Increment the score
			PianoTilesScore.scoreValue += 100;
		}
		// Check if the S key has been pressed at the right time
		else if (Input.GetKeyDown(KeyCode.S) & Rb.transform.position.y < -2 & Rb.transform.position.y > -6 & Rb.transform.position.x > -1.5 & Rb.transform.position.x < 0)
		{
			color.color = Color.yellow;
			PianoTilesScore.scoreValue += 100;
			print("ScoreValue = " + PianoTilesScore.scoreValue);
		}
		// Check D key
		else if (Input.GetKeyDown(KeyCode.D) & Rb.transform.position.y < -2 & Rb.transform.position.y > -6 & Rb.transform.position.x > 0 & Rb.transform.position.x < 1.5)
		{
			color.color = Color.yellow;
			PianoTilesScore.scoreValue += 100;
			print("ScoreValue = " + PianoTilesScore.scoreValue);
		}
		// Check F key
		else if (Input.GetKeyDown(KeyCode.F) & Rb.transform.position.y < -2 & Rb.transform.position.y > -6 & Rb.transform.position.x > 1.5 & Rb.transform.position.x < 3)
		{
			color.color = Color.yellow;
			PianoTilesScore.scoreValue += 100;
			print("ScoreValue = " + PianoTilesScore.scoreValue);
		}
	}


	// Update is called once per frame
	void FixedUpdate()
	{
		if (Rb == null)
		{

		}
		else
		{
			Rb.velocity = -transform.up * tileSpeed;
		}

		if (Rb.transform.position.y < -6 & color.color != Color.yellow)
        {
			Time.timeScale = 0;
			SceneManager.LoadScene(0);
			Debug.Log("You Lost!");
		}
	}

	void OnMouseOver()
    {
		Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

		// Check if mouse click was during the right time and place
		if (Input.GetMouseButtonDown(0) & worldPosition.y < -3.5 & worldPosition.y > -4.5 & Rb.transform.position.y < -2 & Rb.transform.position.y > -6)
		{
			color.color = Color.yellow;
			PianoTilesScore.scoreValue += 100;
		}
    }
}
