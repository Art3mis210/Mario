using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Plant : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            if (GameObject.Find("Player").GetComponent<Player>().size == 0)
            {
                Destroy(collider.gameObject);
                SceneManager.LoadScene("Game Over");
            }
            else
            {
                GameObject.Find("Player").GetComponent<Player>().size--;
                GameObject.Find("Player").transform.localScale = new Vector2(GameObject.Find("Player").transform.localScale.x / 2, GameObject.Find("Player").transform.localScale.y / 2);
                GameObject.Find("Player").GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                Invoke("ChangeRigidBody", 3 / 4);
            }
        }

    }
    private void ChangeRigidBody()
    {
        GameObject.Find("Player").GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }
}
