using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D myBody;

    private Button jumpBtn;

    private bool hasJumped, platformBound;

    public delegate void MoveCamera();
    public static event MoveCamera move;

    private GameObject parent;

    private Text scoreText;
    private int score = 0;
    private string text = "Score: ";

    void Awake()
    {
        jumpBtn = GameObject.Find("JumpButton").GetComponent<Button>();
        jumpBtn.onClick.AddListener(() => Jump());

        myBody = GetComponent<Rigidbody2D>();

        scoreText = GameObject.Find("Score Text").GetComponent<Text>();
        scoreText.text = score.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        if (hasJumped && myBody.velocity.y == 0)
        {
            if (!platformBound)
            {
                hasJumped = false;

                score++;
                scoreText.text = score.ToString();

                transform.SetParent(parent.transform);

                GameplayController.instance.CreatePlatform();

                if (move != null)
                {
                    move();
                }
            }
            else if (parent != null)
            {
                transform.SetParent(parent.transform);
            }
        }
        
    }

    public void Jump()
    {
        if (myBody.velocity.y == 0)
        {
            myBody.velocity = new Vector2(0, 10);
            transform.SetParent(null);
            hasJumped = true;
        }
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Platform")
        {
            parent = target.gameObject;
        }
    }
    void OnCollisionExit2D(Collision2D target)
    {
        if (target.gameObject.tag == "Platform")
        {
            parent = null;
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "MainCamera")
        {
            platformBound = true;
        }
    }
    void OnTriggerExit2D(Collider2D target)
    {
        if (target.tag == "MainCamera")
        {
            platformBound = false;
        }
    }


} //class
