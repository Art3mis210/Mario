using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Plant : MonoBehaviour
{
    public Player PlayerScript;
    private bool ignoreMario;
    void Start()
    {
        ignoreMario=false;
    }
     void Update()
    {
        if (ignoreMario == true)
        {
            Invoke("DontIgnoreMario", 2);
        }
    }
    private void DontIgnoreMario()
    {
        Physics2D.IgnoreCollision(GameObject.Find("Player").GetComponent<BoxCollider2D>(), gameObject.GetComponent<BoxCollider2D>(), false);
        ignoreMario = false;
    }
    private void OnCollisionStay2D(Collision2D collider)
    {

        if (collider.gameObject.tag == "Player")
        {
            int size = GameObject.Find("Player").GetComponent<Player>().size;

            if (ignoreMario != true)
            {
                if (size == 0)
                {
                    GameObject.Find("Mario").GetComponent<Animator>().enabled = true;
                    // Destroy(collider.gameObject);
                    // SceneManager.LoadScene("Game Over");
                }
                else
                {

                    GameObject.Find("Player").GetComponent<Player>().ChangeSize(size - 1);
                    ignoreMario = true;
                }

            }

            else
            {
                Physics2D.IgnoreCollision(collider.gameObject.GetComponent<BoxCollider2D>(), gameObject.GetComponent<BoxCollider2D>());

            }
        }

    }
}

