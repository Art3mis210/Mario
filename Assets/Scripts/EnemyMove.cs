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
    private int deathMove;
    public float movex;
    public bool dead;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();
        ignoreMario=false;
        deathMove = 0;
        dead = false;
        speed = -speed;
    }

    // Update is called once per frame
    void Update()
    {   
        if(deathMove==0)
        {
            rigidBody.velocity = new Vector2(speed * Time.fixedDeltaTime, rigidBody.velocity.y);
            if (ignoreMario == true)
            {
                Invoke("DontIgnoreMario", 2);
            }
        }
        else if(deathMove<5)
        {

            gameObject.transform.position = new Vector3(gameObject.transform.position.x+movex, gameObject.transform.position.y + +0.24f, gameObject.transform.position.z);
            deathMove++;
        }
        else if(deathMove==5)
        {
            EnemyDeath();
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

        if (collider.gameObject.tag == "Player")
        {
            int size = collider.gameObject.GetComponent<Player>().size;
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
                Physics2D.IgnoreCollision(collider.gameObject.GetComponent<BoxCollider2D>(), gameObject.GetComponent<BoxCollider2D>(),true);
                Physics2D.IgnoreCollision(collider.gameObject.GetComponent<BoxCollider2D>(), gameObject.transform.GetChild(0).GetComponent<BoxCollider2D>(),true);
            }
        }

    }
    private void OnCollisionEnter2D(Collision2D collider)
    {
        if(dead==true)
        {
            if (collider.gameObject.tag == "PIPE")
            {
                SR.flipX = !SR.flipX;
                if(speed!=0)
                    speed = -speed;


            }
        }
        else
        {    if (collider.gameObject.tag == "ENDBASE" || collider.gameObject.tag == "PIPE")
            {
                SR.flipX = !SR.flipX;
                if (speed != 0)
                    speed = -speed;
            }

        }
    }
    public void EnemyDeath()
    {
        if (deathMove == 0)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            deathMove = 1;
            speed = 0;
            GameObject.Find("Player").GetComponent<Player>().PlayFireballDeathSound();
            SR.flipY = true;
        }
            
            
    }
    public void StompedEnemy()
    {
        dead = true;
        if (GameObject.Find("Player").gameObject.transform.position.x <= gameObject.transform.position.x)
            speed = 200;
        else
            speed = -200;
        ignoreMario = true;
        rigidBody.gravityScale = 5;
    }

}
