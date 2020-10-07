using UnityEngine;
using System.Collections;

public class CompletePlayerController : MonoBehaviour
{

    public float speed;                //Floating point variable to store the player's movement speed.

    private Rigidbody2D rb2d;        //Store a reference to the Rigidbody2D component required to use 2D Physics.

    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
        {
           Vector2 pos = Vector2.zero;

           if (Input.GetKey("w"))
            {
               pos.y += speed;
            }
           if (Input.GetKey("s"))
            {
               pos.y -= speed;
            }
           if (Input.GetKey("d"))
            {
               pos.x += speed;
            }
           if (Input.GetKey("a"))
            {
               pos.x -= speed;
            }

        rb2d.velocity = pos;
        }