using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private float speed = 1f;

    private float boundLeft = -1.6f, boundRight = 1.6f;

    private bool left;

    void Awake()
    {
        RandomizeMovement();
    }

    // Update is called once per frame
    void Update()
    {
        Move ();
    }

    private void RandomizeMovement()
    {
        if (Random.Range (0,2) == 0)
        {
            left = true;
        }
        else
        {
            left = false;
        }
    }

    private void Move()
    {
        if (left)
        {
            Vector3 temp = transform.position;
            temp.x -= speed * Time.deltaTime;
            transform.position = temp;

            if(transform.position.x < boundLeft)
            {
                left = false;
            }
        }
        else
        {
            Vector3 temp = transform.position;
            temp.x += speed * Time.deltaTime;
            transform.position = temp;

            if (transform.position.x > boundRight)
            {
                left = true;
            }
        }
    }

} //class








