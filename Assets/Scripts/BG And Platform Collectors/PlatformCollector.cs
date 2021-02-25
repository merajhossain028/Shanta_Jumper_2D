using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCollector : MonoBehaviour
{
    private GameObject panel;


    void Awake()
    {
        panel = GameObject.Find("Game Over Panel");
        panel.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Platform")
        {
            target.gameObject.SetActive(false);

        }
        if(target.tag == "Player")
        {
            Time.timeScale = 0f;
            panel.SetActive(true);
        }
    }
} //class
