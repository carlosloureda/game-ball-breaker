using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    /**
    * We create it private to be linked with FindObjectOfType so we can link prefabs
    * programatically as Unity doesn't let us use nested prefabs (but we want them)
    * See: MakeBallStayOverPaddle
    */
    private Paddle paddle;

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
        this.LinkPaddleToBall();
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

    private void OnCollisionExit2D(Collision2D other)
    {
        if (this.gameHasStarted)
        {

            bool isFinalHit = other.gameObject.tag == "Breakable" && other.gameObject.GetComponent<Brick>().IsFinalHit();            // Debug.Log("script: ", script);
            if (!isFinalHit)
                GetComponent<AudioSource>().Play();

        }
    }

    /**
    * We can link prefabs with FindObjectOfType programatically as Unity doesn't
    * let us use nested prefabs (but we want them)
*/
    private void LinkPaddleToBall()
    {
        this.paddle = GameObject.FindObjectOfType<Paddle>();
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
