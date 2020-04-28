using UnityEngine;

public class Level : MonoBehaviour
{
    //parameters
    [SerializeField] int breakableBlocks; //Serialized for debugging purposes
    [SerializeField] Paddle paddle;
    

    // cached reference
    SceneLoader sceneLoader;
    

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }
    public void CountBlocks()
    {
        breakableBlocks++;
    }

    public void BlockDestroyed()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            Invoke("Win", 1f);
        }
    }

    void Win()
    {
        sceneLoader.LoadNextScene();
        paddle.transform.position = new Vector2(8, 0.11f);
    }
  
}
