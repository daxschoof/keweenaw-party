using UnityEngine;

public class frogAI : MonoBehaviour
{
    public Rigidbody2D Rb;
	
	public SpriteRenderer spriteRenderer;
	
	public Sprite forwardMoveSprite;
	
	public Sprite leftWardMoveSprite;
	
	public Sprite backwardMoveSprite;
	
	public Sprite rightwardMoveSprite;

    public float frogAIMoveTimer = 1f;

    public float frogAIMoveTimerEnraged = 0.33f;

    public float frogAIMoveTimerEnraged2 = 0.15f;

    float nextMoveTimer = 0f;

    float enrageTimer;

    float enrageTimer2;
	
	private void Start()
	{
		enrageTimer = Time.time + 5f;
		enrageTimer2 = Time.time + 10f;
	}
	
    void FixedUpdate()
    {
        int randomMove;
        if(Time.time < enrageTimer)
        {
            if (nextMoveTimer <= Time.time)
            {
                randomMove = Random.Range(0, 3);
                if (randomMove == 0)
                {
                    Rb.MovePosition(Rb.position + Vector2.right);
					spriteRenderer.sprite = rightwardMoveSprite;
                }
                else if (randomMove == 1)
                {
                    Rb.MovePosition(Rb.position + Vector2.left);
					spriteRenderer.sprite = leftWardMoveSprite;
                }
                else if (randomMove == 2)
                {
                    Rb.MovePosition(Rb.position + Vector2.up);
					spriteRenderer.sprite = forwardMoveSprite;
                }
                nextMoveTimer = Time.time + frogAIMoveTimer;
            }
        }
        else if (Time.time < enrageTimer2)
        {
            if (nextMoveTimer <= Time.time)
            {
                randomMove = Random.Range(0, 5);
                if (randomMove == 0)
                {
                    Rb.MovePosition(Rb.position + Vector2.right);
					spriteRenderer.sprite = rightwardMoveSprite;
                }
                else if (randomMove == 1)
                {
                    Rb.MovePosition(Rb.position + Vector2.left);
					spriteRenderer.sprite = leftWardMoveSprite;
                }
                else if (randomMove == 2 || randomMove == 3 || randomMove == 4)
                {
                    Rb.MovePosition(Rb.position + Vector2.up);
					spriteRenderer.sprite = forwardMoveSprite;
                }
                nextMoveTimer = Time.time + frogAIMoveTimerEnraged;
            }
        }
        else
        {
            if (nextMoveTimer <= Time.time)
            {
                Rb.MovePosition(Rb.position + Vector2.up);
				spriteRenderer.sprite = forwardMoveSprite;
                nextMoveTimer = Time.time + frogAIMoveTimerEnraged2;
            }
        }
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "car")
        {
            Debug.Log("Got hit!");
            Rb.position = new Vector3((float)4.5, (float)-4.5, 0);
        }
        if (collider.tag == "frog")
        {
            Debug.Log("Hit the player!");
            Rb.position = new Vector3((float)4.5, (float)-4.5, 0);
        }
        if (collider.tag == "leftborder" || collider.tag == "rightborder" || collider.tag == "bottomborder")
        {
            Debug.Log("Hit the border");
            Rb.position = new Vector3((float)4.5, (float)-4.5, 0);
        }
    }
}
