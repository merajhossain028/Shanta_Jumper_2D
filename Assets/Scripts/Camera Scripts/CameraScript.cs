using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private bool canMove;

    private float distance = 4.1f;
    private float newDestination;

    void OnEnable()
    {
        PlayerScript.move += Move;
    }

    void OnDisable()
    {
        PlayerScript.move -= Move;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera();
    }

    private void MoveCamera()
    {
        if (canMove)
        {
            Vector3 temp = transform.position;
            temp.y += 3f * Time.deltaTime;
            transform.position = temp;

            if (transform.position.y >= newDestination)
            {
                canMove = false;
            }
        }
    }

    void Move()
    {
        newDestination = transform.position.y + distance;
        canMove = true;
    }



} //class
