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
    public float speed = 2f;

    //Debug
    public TextMeshProUGUI HPText;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //Player wont exit the limits
        inLimits();

        //Debug
        if (Input.GetKeyDown("space"))
            HP.removeHP();
        if (Input.GetKeyDown("j"))
            HP.addHP();
        HPText.text = HP.showHP().ToString();

        //Debug
        if (Input.GetKeyDown("l"))
        {
            Bullet instBullet = Instantiate(bullet);
            instBullet.setDirection(movement);
            instBullet.transform.position = rb.transform.position;
        }
        if (Input.GetKeyDown("k"))
        {
            BigBullet instBBullet = Instantiate(BigBullet);
            instBBullet.setDirection(movement);
            instBBullet.transform.position = rb.transform.position;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.LogWarning("COLLISION CON BALA");

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
}