using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    //cached reference
    GameSession gameSession;

    private void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameSession.LoseLive();
    }
}
