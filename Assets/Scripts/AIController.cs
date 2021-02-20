using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public float speed = 8f;

    private Rigidbody2D rb;
    private Transform tr;
    private int scorePlayerTwo = 0;

    private BallScript ball;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        tr = gameObject.GetComponent<Transform>();

        ball = GameObject.Find("BallScript").GetComponent<BallScript>();
    }

    void FixedUpdate()
    {
        if (GameMode.AITurn) { 
            float ballY = ball.newBall.GetComponent<BallController>().GetMovementY();
            float direction = ballY - tr.position.y;
            if (Mathf.Abs(direction) > 0.5f)
            {
                if (direction > 0)
                {
                    rb.velocity = new Vector2(0, 1) * speed;
                }
                else if (direction < 0)
                {
                    rb.velocity = new Vector2(0, -1) * speed;
                }
            }
            else
            {
                rb.velocity = Vector2.zero;
            }
        }
    }

    public int GetPlayerTwoScore()
    {
        scorePlayerTwo++;
        return scorePlayerTwo;
    }

    public float GetPositionY()
    {
        return tr.position.y;
    }
}
