using Microsoft.Win32.SafeHandles;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform tr;
    public float speed = 10f;

    private static Vector2 movement;
    private float hitCounter = 0;
    private BallScript ball;

    public float GetMovementY()
    {
        return tr.position.y;
    }

    public void SetMovementVector(Vector2 vector)
    {
        movement = vector;
    }

    private void Start()
    {
        rb.velocity = movement * speed;
        ball = GameObject.Find("BallScript").GetComponent<BallScript>();
    }

    void Update()
    {
        SpeedUp();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            SoundManagerScript.PlayWallHit();
        }
        if (collision.gameObject.tag == "Paddle")
        {
            SetMovementDirection(true);
        }
        if (collision.gameObject.tag == "Paddle2")
        {
            SetMovementDirection(false);
        }
        if (collision.gameObject.tag == "Gate")
        {
            DestroyBall(true);
        }
        if (collision.gameObject.tag == "Gate2")
        {
            DestroyBall(false);
        }
    }

    private void SetMovementDirection(bool isLeft)
    {
        SoundManagerScript.PlayPaddleHit();

        hitCounter++;
        movement.x = -movement.x;
        movement.y = (tr.position.y - ball.GetPlayerPosition(isLeft)) / 2f;
        rb.velocity = movement * speed;

        if (GameMode.AIEnable)
        {
            GameMode.AITurn = isLeft;
        }
    }

    private void DestroyBall(bool isLeft)
    {
        SoundManagerScript.PlayGateHit();

        Destroy(gameObject);

        if (GameMode.AIEnable)
        {
            GameMode.AITurn = false;
        }

        ball.CreateNewBall(isLeft);
    }

    private void SpeedUp()
    {
        if(hitCounter == 2 && speed < 20)
        {
            hitCounter = 0;
            speed += 2f;
        }
    }
}
