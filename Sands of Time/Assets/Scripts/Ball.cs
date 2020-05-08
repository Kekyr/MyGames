using UnityEngine;

public class Ball : MonoBehaviour
{
    // config params    
    public float xPush = 2f;
    public float yPush = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 1.2f;


    // state
    public bool hasStarted = false;
    private Vector2 paddleToBallVector;


    //Cached component references
    public Rigidbody2D myRigidBody2D;
    AudioSource myAudioSource;
    Paddle paddle;

    private void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
        paddle = FindObjectOfType<Paddle>();
        paddleToBallVector = transform.position - paddle.transform.position;
    }

    
    private void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            #if UNITY_STANDALONE || UNITY_WEBPLAYER
            LaunchOnMouseClick();
            #endif
        }
    }

    private void LaunchOnMouseClick()
    {
        #if UNITY_STANDALONE || UNITY_WEBPLAYER
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            myRigidBody2D.velocity = new Vector2(xPush, yPush);
        }
        #endif
        
    }

    

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
        transform.rotation = new Quaternion(0, 0, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2
            (Random.Range(0f, randomFactor),
            Random.Range(0f, randomFactor));

        if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigidBody2D.velocity += velocityTweak;
        }
    }
}
