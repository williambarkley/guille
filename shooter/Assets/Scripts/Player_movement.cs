using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player_movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public HPSystem HP;
    public AudioSource medkit;

    public Bullet bullet;
    public BigBullet BigBullet;

    Vector2 movement;
    Vector2 direction;
    public float speed = 2f;

    float BBulletTimer;
    public TextMeshProUGUI cooldown;

    private void Start()
    {
        direction = new Vector2(0, 1);
        transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg, Vector3.forward);
        BBulletTimer = Functions.COOLDOWN;
    }

    // Update is called once per frame
    void Update()
    {
        move_and_rotate();
        shoot();

        //Player wont exit the limits
        inLimits();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Medkit")
        {
            HP.addHP();
            Destroy(collision.gameObject);
            medkit.Play();
        }
    }

    void inLimits()
    {
        if (rb.position.x > Functions.MAX_X)
            rb.position = new Vector2(Functions.MAX_X, rb.position.y);
        if (rb.position.x < Functions.MIN_X)
            rb.position = new Vector2(Functions.MIN_X, rb.position.y);

        if (rb.position.y > Functions.MAX_Y)
            rb.position = new Vector2(rb.position.x, Functions.MAX_Y);
        if (rb.position.y < Functions.MIN_Y)
            rb.position = new Vector2(rb.position.x, Functions.MIN_Y);
    }

    void move_and_rotate()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (Functions.vectorLenght(movement) != 0)
        {
            direction = movement;
            transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg, Vector3.forward);
        }
    }

    void shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Bullet instBullet = Instantiate(bullet);
            instBullet.setDirection(direction);
            instBullet.transform.position = rb.transform.position;
        }
        if (Input.GetMouseButtonDown(1) && BBulletTimer >= Functions.COOLDOWN)
        {
            BigBullet instBBullet = Instantiate(BigBullet);
            instBBullet.setDirection(direction);
            instBBullet.transform.position = rb.transform.position;
            BBulletTimer = 0;
        }

        if(BBulletTimer < Functions.COOLDOWN)
        {
            BBulletTimer += Time.deltaTime;
        }

        cooldown.text = BBulletTimer.ToString();
    }
}