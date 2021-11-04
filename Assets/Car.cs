using UnityEngine;

public class Car : MonoBehaviour
{
    public Rigidbody2D Rb;

    public float minSpeed = 8f;
    public float maxSpeed = 12f;
    public float carspeed = 1f;

    void Start ()
    {
        carspeed = 10f;
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
