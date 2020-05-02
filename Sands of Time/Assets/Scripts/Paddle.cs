using UnityEngine;

public class Paddle : MonoBehaviour
{
    // configuration parameters
    [SerializeField] float minX = 0.49f;
    [SerializeField] float maxX = 15.4710f;
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] Level level;
    public Vector3 paddlePos=new Vector3(8,0.11f,0);
    

    //cached references
    GameSession theGameSession;
    Ball theBall;
    Rigidbody2D rb;
    


    void Start()
    {
        theGameSession = FindObjectOfType<GameSession>();
        theBall = FindObjectOfType<Ball>();
        rb = GetComponent<Rigidbody2D>();
    }

    #if UNITY_STANDALONE || UNITY_WEBPLAYER
    void Update()
    {
        paddlePos = new Vector3(transform.position.x, transform.position.y,0);
        paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = paddlePos;
    }
    #else
    void FixedUpdate()
    {
        //paddlePos.x = Mathf.Clamp(paddlePos.x, minX, maxX);
        paddlePos = paddlePos * theGameSession.gameSpeed * Time.deltaTime;
        rb.MovePosition(rb.transform.position + paddlePos);
    }
    #endif

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

    public void MoveLeft()
    {
        paddlePos.x -= 2;

    }
}
