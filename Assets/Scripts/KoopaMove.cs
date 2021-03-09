using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class KoopaMove : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    public float speed=0.1f;
    private SpriteRenderer SR;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
       rigidBody.velocity = new Vector2(-speed * Time.fixedDeltaTime, rigidBody.velocity.y);
    }
    private void OnCollisionStay2D(Collision2D collider)
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
                Invoke("ChangeRigidBody", 3/4);
            }
        }

    }
    private void ChangeRigidBody()
    {
        GameObject.Find("Player").GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }
    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "ENDBASE" || collider.gameObject.tag == "PIPE")
        {
            if (SR.flipX == true)
                SR.flipX = false;
            else
                SR.flipX = true;
            if (speed != 0)
                speed = -speed;


        }
    }

}
