using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;

    private bool movingRight = true;

    public Transform groundDetection;
    public Transform wallDetection;
    public float distanceGround;
    public float distanceWall;

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distanceGround);
        RaycastHit2D wallInfo = Physics2D.Raycast(groundDetection.position, Vector2.right, distanceWall);
        if(groundInfo.collider == false || wallInfo.collider == true)
        {
            if(movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }

    }
}
