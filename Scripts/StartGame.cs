using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
 
    public void StartButton()
    {
        SceneManager.LoadScene("MyGame");
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void StartInstructions()
    {
        SceneManager.LoadScene("Instructions");
    }

}
