using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldDownButtons : MonoBehaviour
{
    public bool isRacePressed = false;
    public bool isBrakePressed = false;
    [SerializeField] Paddle paddle;
    [SerializeField] int paddleSpeed = 12;
    GameObject button;
    Ball theBall;

    

    void Update()
    {
        if(isRacePressed)
        {
            if (button.name == "Left Button")
            {
                paddle.paddlePos.x -= paddleSpeed;
            }
            else
            {
                paddle.paddlePos.x += paddleSpeed;
            }
        }
        
    }

    public void onPointerDownRaceButton(GameObject but)
    {
        button = but;
        isRacePressed=true;
    }
    public void onPointerUpRaceButton(GameObject but)
    {
        button = but;
        isRacePressed = false;
    }

    public void LaunchOnButtonClick()
    {
        theBall = FindObjectOfType<Ball>();
        theBall.hasStarted = true;
        theBall.myRigidBody2D.velocity = new Vector2(theBall.xPush, theBall.yPush);
    }
}
