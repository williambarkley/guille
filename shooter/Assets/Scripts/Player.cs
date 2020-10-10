using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    //Components from this gameObject
    Rigidbody2D rb;
    HPSystem HP;

    //Components from other objects
    public NormalBullet bullet;
    public BigBullet BigBullet;
    public AudioSource medkit;
    //Debug
    public TextMeshProUGUI cooldown;
    public TextMeshProUGUI score;

    //direction will store last valid movement
    Vector2 movement;
    Vector2 direction;
    public float speed = 2f;

    //Timer for bigBullets
    float BBulletTimer;

    private void Start()
    {
        //We get components
        components();

        //We initialize values
        direction = new Vector2(0, 1);
        transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg, Vector3.forward);
        BBulletTimer = Constant.COOLDOWN;
    }

    void Update()
    {
        move_and_rotate();
        shoot();

        //Player wont exit the limits
        inLimits();

        //Debug
        score.text = Constant.actual_score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If colliding with medkits, we destroy them, play a sound and add 1HP
        if (collision.gameObject.tag == "Medkit")
        {
            HP.addHP();
            Destroy(collision.gameObject);
            medkit.Play();
        }
        //If colliding with asteroids, we destroy them and remove 1HP from the player
        if (collision.gameObject.tag == "Asteroid")
        {
            HP.removeHP();
            Destroy(collision.gameObject);
        }
    }

    //Checks if the player is withing the stablished boundaries and stops them from going beyond
    void inLimits()
    {
        if (rb.position.x > Constant.MAX_X)
            rb.position = new Vector2(Constant.MAX_X, rb.position.y);
        if (rb.position.x < Constant.MIN_X)
            rb.position = new Vector2(Constant.MIN_X, rb.position.y);

        if (rb.position.y > Constant.MAX_Y)
            rb.position = new Vector2(rb.position.x, Constant.MAX_Y);
        if (rb.position.y < Constant.MIN_Y)
            rb.position = new Vector2(rb.position.x, Constant.MIN_Y);
    }

    //Gets movement status and rotates the player accordingly
    void move_and_rotate()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //Rotation
        if (Functions.vectorLenght(movement) != 0)
        {
            direction = movement;
            transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg, Vector3.forward);
        }

        //We move the player at constant speed
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    //We check if the player is clicking to shoot and instantiate the projectiles
    void shoot()
    {
        //We instantiate them at the position of the player and give them direction
        //Normal bullet
        if (Input.GetMouseButtonDown(0))
        {
            NormalBullet instBullet = Instantiate(bullet);
            instBullet.setDirection(direction);
            instBullet.transform.position = rb.transform.position;
        }
        //Big bullet (has a cooldown)
        if (Input.GetMouseButtonDown(1) && BBulletTimer >= Constant.COOLDOWN)
        {
            BigBullet instBBullet = Instantiate(BigBullet);
            instBBullet.setDirection(direction);
            instBBullet.transform.position = rb.transform.position;

            //Reset the timer
            BBulletTimer = 0;
        }

        //When the big bullet is on cooldown, we increase the timer
        if (BBulletTimer < Constant.COOLDOWN)
        {
            BBulletTimer += Time.deltaTime;
        }

        //Debug
        cooldown.text = BBulletTimer.ToString();
    }

    //We get the components from the gameObject
    void components()
    {
        rb = GetComponent<Rigidbody2D>();
        HP = GetComponent<HPSystem>();
    }
}