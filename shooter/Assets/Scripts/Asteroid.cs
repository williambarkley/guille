using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : Bullet
{
    //The ammount of bullets it will resist
    int HP;

    private void Start()
    {
        //We initialize values
        speed = randomSpeed();
        HP = Constant.ASTEROID_HP;

        //We give the asteroid a random rotation
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, Functions.rand(0, 360));
    }

    private void Update()
    {
        if(HP <= 0)
        {
            asteroid_score();
            Destroy(gameObject);
        }
    }

    //Returns a random speed value according to some parameters
    float randomSpeed()
    {
        //Speed = base * rand(0.75 - 1.25)
        double rSpeed = Constant.ASTEROID_SPEED * Functions.rand(1 - Constant.ASTEROID_SPEED_VARIATION, 1 + Constant.ASTEROID_SPEED_VARIATION);
        return (float)rSpeed;
    }

    public void removeHP()
    {
        HP--;
    }
    
    //Gives the score from destroying an asteroid
    public void asteroid_score()
    {
        Constant.actual_score += Constant.ASTEROID_SCORE;
    }
}
