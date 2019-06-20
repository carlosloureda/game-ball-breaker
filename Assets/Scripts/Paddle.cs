using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    /**
    *
    *  -0.5f for mouse setting in middle of paddle
    */
    const float MOUSE_TO_SCREEN_POS = -0.5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 paddlePos = new Vector3(0f, this.transform.position.y, 0f);
        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
        paddlePos.x = Mathf.Clamp(mousePosInBlocks + MOUSE_TO_SCREEN_POS, 0f, 15f);
        this.transform.position = paddlePos;
    }
}
