using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallScript : MonoBehaviour
{
    public GameObject ball;
    public GameObject newBall;

    private PlayerOneController playerOne;
    private PlayerTwoController playerTwo;
    private AIController playerAI;
    private Text scoreOne;
    private Text scoreTwo;

    private float ballPositionX;
    private float ballMovementDirection;

    void Awake()
    {
        playerOne = GameObject.Find("Player One").GetComponent<PlayerOneController>();
        playerTwo = GameObject.Find("Player Two").GetComponent<PlayerTwoController>();
        playerAI = GameObject.Find("Player Two").GetComponent<AIController>();

        if (GameMode.AIEnable)
        {
            Destroy(playerTwo);
        } else
        {
            Destroy(playerAI);
        }

        scoreOne = GameObject.Find("Score2").GetComponent<Text>();
        scoreTwo = GameObject.Find("Score1").GetComponent<Text>();

        CreateBall(false);
    }

    public float GetPlayerPosition(bool isLeft)
    {
        if (isLeft)
        {
            return playerOne.GetPositionY();
        } else if (GameMode.AIEnable)
        {
            return playerAI.GetPositionY();
        } else
        {
            return playerTwo.GetPositionY();
        }
    }

    public void CreateNewBall(bool isLeft)
    {
        if (isLeft)
        {
            scoreOne.text = "" + playerOne.GetPlayerOneScore();
        } else if (GameMode.AIEnable)
        {
            scoreTwo.text = "" + playerAI.GetPlayerTwoScore();
        } else
        {
            scoreTwo.text = "" + playerTwo.GetPlayerTwoScore();
        }
        CreateBall(isLeft);
    }

    public void CreateBall(bool isLeft)
    {
        ChangeBallPositionX(isLeft);
        StartCoroutine(Init(isLeft));
    }

    private void ChangeBallPositionX(bool isLeft)
    {
        if (isLeft)
        {
            ballPositionX = 3f;
            ballMovementDirection = -1;
        } else
        {
            ballPositionX = -3f;
            ballMovementDirection = 1;
        }
    }

    IEnumerator Init(bool isLeft)
    {
        yield return new WaitForSeconds(1f);

        Instantiate(ball, new Vector3(ballPositionX, 0, 0), Quaternion.identity);

        ball.GetComponent<BallController>().SetMovementVector(new Vector2(ballMovementDirection, 0));

        newBall = GameObject.Find("Ball(Clone)");

        if (isLeft && GameMode.AIEnable)
        {
            GameMode.AITurn = false;
        }
        else
        {
            GameMode.AITurn = true;
        }
    }
}
