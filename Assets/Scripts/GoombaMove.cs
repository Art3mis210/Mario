using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GoombaMove : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    public  float speed = 50f;
    private SpriteRenderer SR;
    public Player PlayerScript;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody.velocity = new Vector2(-speed*Time.fixedDeltaTime , rigidBody.velocity.y);
    }
    private void OnCollisionStay2D(Collision2D collider)
    {
        int size = GameObject.Find("Player").GetComponent<Player>().size;
        if (collider.gameObject.tag == "Player")
        {
            if (size == 0)
            {
                Destroy(collider.gameObject);
                SceneManager.LoadScene("Game Over");
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
    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "ENDBASE" || collider.gameObject.tag == "PIPE")
        {
            if (speed != 0)
                speed = -1*speed;


        }
    }

}
