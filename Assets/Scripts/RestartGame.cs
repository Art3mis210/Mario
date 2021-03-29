using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartGame : MonoBehaviour
{

    public void GoToMainMenu()
    {
        Destroy(GameObject.Find("Canvas2"));
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu");
    }
}
