using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    // config params
    [Range(0.1f,10f)] public float gameSpeed = 0.8f;
    [SerializeField] int scorePerBlockDestroyed = 83;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlayEnabled;
    [SerializeField] GameObject ball;
    [SerializeField] GameObject[] lives;

    // state variables
    [SerializeField] int currentScore = 0;
    [SerializeField] int currentLives = 3;

    // cached reference
    Paddle paddle;

    private void Awake()
    {
        int gameSessionCount = FindObjectsOfType<GameSession>().Length;
        if (gameSessionCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    
    private void Start()
    {
        scoreText.text = currentScore.ToString();
        paddle = FindObjectOfType<Paddle>();
    }

    private void Update()
    {
        Time.timeScale = gameSpeed;  
    }

    public void AddToScore()
    {
        currentScore += scorePerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }

    public void LoseLive()
    {
        currentLives--;
        if (currentLives==0)
        {
            ResetGame();
            SceneManager.LoadScene("Game Over");
        }
        else
        {
            Destroy(lives[currentLives]);
            paddle.transform.position = new Vector2(8,0.2f);
            GameObject theBall = Instantiate(ball, new Vector2(8,0.55f), transform.rotation); 
            currentScore = 0;
            scoreText.text = currentScore.ToString();
        }
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}
