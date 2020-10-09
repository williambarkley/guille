﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBullet : Bullet
{
    private void Start()
    {
        //We initialize values
        speed = Constant.BIG_BULLET_SPEED;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //When colliding with an asteroid, we destroy it and give some score
        if (collision.gameObject.tag == "Asteroid")
        {
            collision.GetComponent<Asteroid>().asteroid_score();
            Destroy(collision.gameObject);
        }
    }
}