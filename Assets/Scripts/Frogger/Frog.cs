using UnityEngine;

public class Frog : MonoBehaviour
{
    public Rigidbody2D Rb;
    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 0)
        {

        }
        else
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Rb.MovePosition(Rb.position + Vector2.right);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Rb.MovePosition(Rb.position + Vector2.left);
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Rb.MovePosition(Rb.position + Vector2.up);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Rb.MovePosition(Rb.position + Vector2.down);
            }
        }
    }

    void OnTriggerEnter2D (Collider2D collider)
    {
        if (collider.tag == "car")
        {
            Debug.Log("Got hit!");
            Rb.position = new Vector3(0, (float)-4.5, 0);
        }
    }
}
