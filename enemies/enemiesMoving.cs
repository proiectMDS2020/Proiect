using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class enemiesMoving : MonoBehaviour
{
    public float speed;

    public bool moveRight;

    public bool moveUp;

    public bool playIdle;

    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        if (playIdle)
        {
            animator.SetBool("playIdle", true);
        }
        else
        {
            if (gameObject.CompareTag("upDown"))
            {
                if (moveUp)
                {
                    transform.Translate(0, Time.deltaTime * speed, 0);
                    transform.localScale = new Vector2(1, 1);
                }
                else
                {
                    transform.Translate(0, -Time.deltaTime * speed, 0);
                    transform.localScale = new Vector2(1, 1);
                }
            }
            else
            {
                if (moveRight)
                {
                    transform.Translate(Time.deltaTime * speed, 0, 0);
                    if (gameObject.CompareTag("superPiggy"))
                    {
                        transform.localScale = new Vector2(-2, 2);
                    }
                    else
                    {
                        transform.localScale = new Vector2(-1, 1);
                    }
                }
                else
                {
                    transform.Translate(-Time.deltaTime * speed, 0, 0);
                    if (gameObject.CompareTag("superPiggy"))
                    {
                        transform.localScale = new Vector2(2, 2);
                    }
                    else
                    {
                        transform.localScale = new Vector2(1, 1);
                    }
                }
            }
        }
    } 

    void OnTriggerEnter2D(Collider2D trigg)
    {
        if (trigg.gameObject.CompareTag("turn"))
        {
            if (moveRight)
            {
                moveRight = false;
            }
            else
            {
                moveRight = true;
            }
        }
        else
        {
            if (moveUp)
            {
                moveUp = false;
            }
            else
            {
                moveUp = true;
            }
        }
    }
}
