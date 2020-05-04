using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldDownButtons : MonoBehaviour
{
    public bool isRacePressed = false;
    public bool isBrakePressed = false;
    [SerializeField] Paddle paddle;
    GameObject button;



    void Update()
    {
        if(isRacePressed)
        {
            if (button.name == "Left Button")
            {
                paddle.paddlePos.x -= 2;
            }
            else
            {
                paddle.paddlePos.x += 2;
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


}
