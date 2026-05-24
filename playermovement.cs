using UnityEngine;

public class playermovement : MonoBehaviour
{
    public float speed;
    public int walking;
    public int direction;
    public Rigidbody2D richard;
    public Animator anna;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        direction = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up*speed*Time.deltaTime,Space.World);
            walking = 1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left*speed*Time.deltaTime,Space.World);
            direction = 1;
            walking = 1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right*speed*Time.deltaTime,Space.World);
            direction = 2;
            walking = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down*speed*Time.deltaTime,Space.World);
            walking = 1;
        }
        else 
        {
            walking = 0;
        }
        anna.SetInteger("laufend", walking);
        anna.SetInteger("richtung", direction);
    }
}
