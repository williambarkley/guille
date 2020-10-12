using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    Transform player;
    float playerDistance;
    float rotationSpeed;
    float speed;
    Rigidbody2D rb;
    Vector2 direction;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();

        speed = Constant.ENEMY_SPEED;
        rotationSpeed = Constant.ENEMY_ROTATION_SPEED;
    }

    void Update()
    {
        playerDistance = Vector3.Distance(player.position, rb.position);

        if (playerDistance < Constant.ENEMY_LOOK_RADIUS)
            LookAtPlayer();
        if (playerDistance < Constant.ENEMY_CHASE_RADIUS)
            chase();
        else
            rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);

        //Destroy if out of bounds
        if (rb.position.x > Constant.MAX_X + Constant.LIMIT_OFFSET
         || rb.position.x < Constant.MIN_X - Constant.LIMIT_OFFSET
         || rb.position.y > Constant.MAX_Y + Constant.LIMIT_OFFSET
         || rb.position.y < Constant.MIN_Y - Constant.LIMIT_OFFSET)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //When colliding with player
        if (collision.gameObject.tag == "Player")
        {
            if (!collision.GetComponent<HPSystem>().invulnerable)
            {

                collision.GetComponent<HPSystem>().removeHP();
                Destroy(gameObject);
            }
        }
    }

    void LookAtPlayer()
    {
        Vector3 rotation = new Vector3(player.position.x - rb.position.x, player.position.y - rb.position.y, transform.position.z);
        Quaternion finalRotation = Quaternion.AngleAxis(Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, finalRotation, Time.deltaTime * rotationSpeed);
    }

    void chase()
    {
        Vector2 playerDirection = new Vector2(player.position.x - rb.position.x, player.position.y - rb.position.y);
        Functions.normalize(ref playerDirection);
        rb.MovePosition(rb.position + playerDirection * speed * Time.deltaTime);
    }

    public void setDirection(Vector2 direction_)
    {
        direction = direction_;
    }
}