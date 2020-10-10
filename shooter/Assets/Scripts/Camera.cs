using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Rigidbody2D player;
    Vector2 position;

    // Update is called once per frame
    void Update()
    {
        if (player.position.x > Constant.CAM_MIN_X && player.position.x < Constant.CAM_MAX_X)
            transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
        if (player.position.y > Constant.CAM_MIN_Y && player.position.y < Constant.CAM_MAX_Y)
            transform.position = new Vector3(transform.position.x, player.position.y, transform.position.z);
    }
}
