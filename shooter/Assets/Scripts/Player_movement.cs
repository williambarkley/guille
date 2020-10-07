using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    const int MAX_X = 3;
    const int MIN_X = -3;
    const int MAX_Y = 3;
    const int MIN_Y = -3;


    public Rigidbody2D rb;
    public HPSystem HP;

    Vector2 movement;
    public float speed = 2f;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //Player wont exit the limits
        inLimits();

        if (Input.GetKeyDown("space"))
            HP.removeHP();
        if (Input.GetKeyDown("j"))
            HP.addHP();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    void inLimits()
    {
        if (rb.position.x > MAX_X)
            rb.position = new Vector2(MAX_X, rb.position.y);
        if (rb.position.x < MIN_X)
            rb.position = new Vector2(MIN_X, rb.position.y);

        if (rb.position.y > MAX_Y)
            rb.position = new Vector2(rb.position.x, MAX_Y);
        if (rb.position.y < MIN_Y)
            rb.position = new Vector2(rb.position.x, MIN_Y);
    }
}