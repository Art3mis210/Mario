using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Mario : MonoBehaviour
{
    public GameObject Canvas;
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
        if (n == 0)//killed by enemy
        {
            
            DontDestroyOnLoad(Canvas);
            Canvas.SetActive(true);
            SceneManager.LoadScene("Game Over");
        }

    }
}
