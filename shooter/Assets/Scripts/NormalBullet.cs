using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : Bullet
{
    private void Start()
    {
        //We initialize values
        speed = Constant.BULLET_SPEED;

        //We get components
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //When colliding with an asteroid, we remove 1HP and destroy the bullet
        if (collision.gameObject.tag == "Asteroid")
        {
            collision.GetComponent<Asteroid>().removeHP();
            Destroy(gameObject);
        }
    }
}
