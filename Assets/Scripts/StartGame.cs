using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public GameObject music;
    // Start is called before the first frame update
    void Start()
    {
        if (FindObjectsOfType<AudioSource>().Length == 0)
        {
            Instantiate(music);
         //   GameObject.Find("Audio(clone)").GetComponent<AudioSource>().Play();
        }
        if(GameObject.FindGameObjectsWithTag("BG").Length>1)
        {
            Destroy(GameObject.Find("BACKGROUND"));
        }
    }
    public void StartTheGame()
    {
        
        SceneManager.LoadScene("Game");
        

    }
    public void ControlsMenu()
    {
        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("AUDIO"));
        DontDestroyOnLoad(GameObject.Find("BACKGROUND"));
        SceneManager.LoadScene("Controls");

    }
    public void CreditsMenu()
    {
        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("AUDIO"));
        DontDestroyOnLoad(GameObject.Find("BACKGROUND"));
        SceneManager.LoadScene("Credits");
    }
    public void GoToMainMenu()
    {
        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("AUDIO"));
        SceneManager.LoadScene("Main Menu");
    }
    public void ExitTheGame()
    {
        Application.Quit();
    }
}
