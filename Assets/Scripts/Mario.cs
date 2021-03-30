using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Mario : MonoBehaviour
{
    public GameObject Canvas;
    public Text Result;
    void Update()
    {
        if (gameObject.transform.GetChild(0).transform.position.y <-40.27)
        {
            GameOverLoad(0);
        }
    }
    public void MarioDeathAnimation()
    {
        gameObject.transform.GetChild(0).GetComponent<Player>().PlayerDeathAnimation();
    }
    public void GameOverLoad(int n)
    {
        Result.text = n.ToString();
        DontDestroyOnLoad(Canvas);
        SceneManager.LoadScene("Game Over");
       // Canvas.SetActive(false);
    }
}
