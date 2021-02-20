using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneController : MonoBehaviour
{
    public float speed = 10f;

    private Rigidbody2D rb;
    private Transform tr;
    private int scorePlayerOne = 0;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        tr = gameObject.GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        rb.velocity = Vector2.up * Input.GetAxis("Player1") * speed;
    }

    public int GetPlayerOneScore()
    {
        scorePlayerOne++;
        return scorePlayerOne;
    }

    public float GetPositionY()
    {
        return tr.position.y;
    }
}
