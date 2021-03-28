using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mario : MonoBehaviour
{
    void Update()
    {
        if (gameObject.transform.GetChild(0).transform.position.y <-40.27)
        {
            SceneManager.LoadScene("Game Over");
        }
    }
    public void MarioDeathAnimation()
    {
        gameObject.transform.GetChild(0).GetComponent<Player>().PlayerDeathAnimation();
    }
}
