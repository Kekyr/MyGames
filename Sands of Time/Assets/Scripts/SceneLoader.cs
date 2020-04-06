using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
   public void LoadNextScene()
   {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;//получаем индекс текущей сцены из build settings
        SceneManager.LoadScene(currentSceneIndex + 1);
   }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

