using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartGame : MonoBehaviour
{
    int i;
    void Start()
    {
        i = 0;
    }
    private void Update()
    {
        if(i==0)
        {
            UpdateScore();
            i++;
        }
    }
    public void GoToMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu");
    }
    public void PlayAgain()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    private void UpdateScore()
    {
        GameObject canvas = GameObject.Find("Canvas");
        GameObject CANVASEND = GameObject.Find("CanvasEND");
        //   canvas.transform.GetChild(10).GetComponent<Text>().text == "0"
        if (canvas.transform.GetChild(10).GetComponent<Text>().text == "0")
        {
            CANVASEND.transform.GetChild(3).gameObject.SetActive(true);
        }
        else if (canvas.transform.GetChild(10).GetComponent<Text>().text == "1")
        {
            CANVASEND.transform.GetChild(4).gameObject.SetActive(true);
        }
        else if (canvas.transform.GetChild(10).GetComponent<Text>().text == "2")
        {
            CANVASEND.transform.GetChild(5).gameObject.SetActive(true);
        }
        string[] x = canvas.transform.GetChild(6).GetComponent<Text>().text.Split(':');
        CANVASEND.transform.GetChild(8).GetComponent<Text>().text = x[1];
        CANVASEND.transform.GetChild(9).GetComponent<Text>().text = canvas.transform.GetChild(7).GetComponent<Text>().text;
        CANVASEND.transform.GetChild(10).GetComponent<Text>().text = canvas.transform.GetChild(9).GetComponent<Text>().text;
        Destroy(GameObject.Find("Canvas"));
        
    }
}
