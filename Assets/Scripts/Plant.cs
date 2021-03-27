using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Plant : MonoBehaviour
{
    public Player PlayerScript;
    private void OnCollisionEnter2D(Collision2D collider)
    {
        int size = GameObject.Find("Player").GetComponent<Player>().size;
        if (collider.gameObject.tag == "Player")
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
                GameObject.Find("Player").GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                Invoke("ChangeRigidBody", 3/4);
            }
        }

    }
    private void ChangeRigidBody()
    {
        GameObject.Find("Player").GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }
}
