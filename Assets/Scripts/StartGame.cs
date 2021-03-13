using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    public void StartTheGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void ExitTheGame()
    {
        Application.Quit();
    }
}
