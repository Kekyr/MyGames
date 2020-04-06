using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // configuration parameters
    [SerializeField] float minX = 0.49f;
    [SerializeField] float maxX = 15.4710f;
    [SerializeField] float screenWidthInUnits = 16f;
    

    void Start()
    {
        
    }

    
    void Update()
    {
        float mousePosInUnits=Input.mousePosition.x/Screen.width*16;
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(mousePosInUnits, minX, maxX);
        transform.position = paddlePos;
    }
}
