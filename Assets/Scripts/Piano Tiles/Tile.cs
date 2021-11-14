using UnityEngine;

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
	}

	void OnMouseOver()
    {
		if (Input.GetMouseButtonDown(0))
        {
			color.color = Color.yellow;
        }
    }
}
