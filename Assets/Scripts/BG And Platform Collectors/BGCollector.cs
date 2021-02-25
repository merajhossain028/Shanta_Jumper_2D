using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGCollector : MonoBehaviour
{
    private GameObject[] bgs;

    private float firstY;

    void Awake()
    {
        bgs = GameObject.FindGameObjectsWithTag("Background");

        firstY = bgs[0].transform.position.y;

        for (int i = 1; i < bgs.Length; i++)
        {
            if (firstY < bgs[i].transform.position.y)
            {
                firstY = bgs[i].transform.position.y;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Background")
        {
            Vector3 temp = target.transform.position;
            float height = ((BoxCollider2D)target).size.y;

            temp.y = firstY + height;

            target.transform.position = temp;

            firstY = temp.y;
        }
    }


}//class

