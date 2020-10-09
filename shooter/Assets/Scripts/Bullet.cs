using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    float speed = Functions.BULLET_SPEED;
    Vector2 direction;

    // Update is called once per frame
    void Update()
    {
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);

        if (rb.position.x > Functions.MAX_X + Functions.LIMIT_OFFSET
         || rb.position.x < Functions.MIN_X - Functions.LIMIT_OFFSET
         || rb.position.y > Functions.MAX_Y + Functions.LIMIT_OFFSET
         || rb.position.y < Functions.MIN_Y - Functions.LIMIT_OFFSET)
                Destroy(gameObject);
    }

    public void setDirection(Vector2 direction_)
    {
        direction = direction_;
    }

}
