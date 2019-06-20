using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Paddle paddle;

    /**
    * The 'y' distance from the ball and the paddle. It is used at start, so
    * in the game is a 'constant' once it is instanciated
    */
    private Vector3 paddleToBallVector;
    /**
    * ball behaves differently when the game start4ed (ball launched) or not (ball
    * on the paddle)
    */
    private bool gameHasStarted = false;
    // Start is called before the first frame update
    void Start()
    {
        this.paddleToBallVector = this.transform.position - paddle.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!this.gameHasStarted)
        {
            this.MakeBallStayOverPaddle();
            this.ListenForMousePressToLanchBall();
        }
    }

    private void MakeBallStayOverPaddle()
    {
        this.transform.position = paddle.transform.position + paddleToBallVector;
    }
    private void ListenForMousePressToLanchBall()
    {

        if (Input.GetMouseButtonDown(0))
        {
            this.gameHasStarted = true;
            // launch ball though its rigidbody2D
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
        }
    }
}
