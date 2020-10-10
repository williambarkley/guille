using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected float speed;
    protected Rigidbody2D rb;

    //it will remain constant
    Vector2 direction;

    void Update()
    {
        //Moves at constant speed and direction
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);

        //Destroy if out of bounds
        if (rb.position.x > Constant.MAX_X + Constant.LIMIT_OFFSET
         || rb.position.x < Constant.MIN_X - Constant.LIMIT_OFFSET
         || rb.position.y > Constant.MAX_Y + Constant.LIMIT_OFFSET
         || rb.position.y < Constant.MIN_Y - Constant.LIMIT_OFFSET)
                Destroy(gameObject);
    }

    //To determine direction at prefab creation
    public void setDirection(Vector2 direction_)
    {
        direction = direction_;
    }
}
