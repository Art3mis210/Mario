using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemyMove : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    public float speed = 0.1f;
    private SpriteRenderer SR;
    private bool ignoreMario;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();
        ignoreMario=false;
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody.velocity = new Vector2(-speed * Time.fixedDeltaTime, rigidBody.velocity.y);
        if(ignoreMario==true)
        {
            Invoke("DontIgnoreMario", 2);    
        }
        if (gameObject.transform.position.y < -20)
            Destroy(gameObject);
    }
    private void DontIgnoreMario()
    {
        Physics2D.IgnoreCollision(GameObject.Find("Player").GetComponent<BoxCollider2D>(), gameObject.GetComponent<BoxCollider2D>(), false);
        Physics2D.IgnoreCollision(GameObject.Find("Player").GetComponent<BoxCollider2D>(), gameObject.transform.GetChild(0).GetComponent<BoxCollider2D>(), false);
        ignoreMario = false;
    }
    private void OnCollisionStay2D(Collision2D collider)
    {
        int size = GameObject.Find("Player").GetComponent<Player>().size;
        if (collider.gameObject.tag == "Player")
        {

            if (ignoreMario != true)
            {
                if (size == 0)
                {
                    GameObject.Find("Mario").GetComponent<Animator>().enabled = true;
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
                Physics2D.IgnoreCollision(collider.gameObject.GetComponent<BoxCollider2D>(), gameObject.transform.GetChild(0).GetComponent<BoxCollider2D>());
            }
        }

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
    private void EnemyDeath()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        rigidBody.constraints = RigidbodyConstraints2D.FreezePositionX;
        gameObject.GetComponent<Animator>().enabled = false;
        speed = 0;
    }

}
