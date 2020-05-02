using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldDownButtons : MonoBehaviour
{
    public bool isRacePressed = false;
    public bool isBrakePressed = false;
    [SerializeField] Paddle paddle;



    void Update()
    {
        if(isRacePressed)
        {
            paddle.paddlePos.x -= 2;
        }
        else if (!isRacePressed)
        {

        }
    }

    public void onPointerDownRaceButton()
    {
        isRacePressed=true;
    }
    public void onPointerUpRaceButton()
    {
        isRacePressed = false;
    }
}
