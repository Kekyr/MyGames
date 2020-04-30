using UnityEngine;

public class Paddle : MonoBehaviour
{
    // configuration parameters
    [SerializeField] float minX = 0.49f;
    [SerializeField] float maxX = 15.4710f;
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] Level level;
    Vector2 paddlePos=new Vector2(8,0.11f);

    //cached references
    GameSession theGameSession;
    Ball theBall;
    


    void Start()
    {
        theGameSession = FindObjectOfType<GameSession>();
        theBall = FindObjectOfType<Ball>();
    }

    void Update()
    {
        #if UNITY_STANDALONE || UNITY_WEBPLAYER
        
        paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = paddlePos;
        
        #else

        paddlePos.x = Mathf.Clamp(paddlePos.x, minX, maxX);
        transform.position = paddlePos;

        #endif
    }


    private float GetXPos()
    {
        
        if(theGameSession.IsAutoPlayEnabled())
        {
            return theBall.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * 16;
        }

    }

    public void MoveRight()
    {
        paddlePos.x += 2;
        
    }

    public void MoveLeft ()
    {
        paddlePos.x -= 2;
        
    }
}
