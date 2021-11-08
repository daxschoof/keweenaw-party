using UnityEngine;

public class Car : MonoBehaviour
{
    public Rigidbody2D Rb;

    public float minSpeed = 8f;
    public float maxSpeed = 12f;
    public float carspeed = 1f;
	
	public SpriteRenderer spriteRenderer;
	
	public Sprite carSprite1;
	public Sprite carSprite2;
	public Sprite carSprite3;
	public Sprite carSprite4;

    void Start ()
    {
        carspeed = 10f;
		
		int sprite = Random.Range(0, 4);
		
		if (sprite == 0)
		{
			spriteRenderer.sprite = carSprite1;
		}
		else if (sprite == 1)
		{
			spriteRenderer.sprite = carSprite2;
		}
		else if (sprite == 2)
		{
			spriteRenderer.sprite = carSprite3;
		}
		else if (sprite == 3)
		{
			spriteRenderer.sprite = carSprite4;
		}
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if(Rb == null)
        {

        }
        else
        {
            Vector2 forward = new Vector2(transform.right.x, transform.right.y);
            Rb.MovePosition(Rb.position + forward * Time.fixedDeltaTime * carspeed);
            Destroy(Rb, 5f);
        }
    }
}
