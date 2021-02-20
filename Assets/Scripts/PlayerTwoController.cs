using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoController : MonoBehaviour
{
    public float speed = 10f;

    private Rigidbody2D rb;
    private Transform tr;
    private int scorePlayerTwo = 0;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        tr = gameObject.GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        rb.velocity = Vector2.up * Input.GetAxis("Player2") * speed;
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
