using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
    public int NumberOfScene;
    public void LoadNewScene()
    {
        SceneManager.LoadScene(NumberOfScene);
    }
    public void QuitOfGame()
    {
        Application.Quit();
    }
}
