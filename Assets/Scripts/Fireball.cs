﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rigidBody;
    private Animator fireAnimator;
    private int speed;
    void Start()
    {
        fireAnimator = GetComponent<Animator>();
        rigidBody=GetComponent<Rigidbody2D>();
        if (GameObject.Find("Player").GetComponent<SpriteRenderer>().flipX == true)
            speed = -5;
        else
            speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
        rigidBody.velocity=new Vector2(speed,0);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="ENEMY"|| collision.gameObject.tag == "Plant")
        {
            fireAnimator.SetBool("DestroyFireball", true);
            
            GameObject.Find("Player").GetComponent<Player>().score += 500;
            if (collision.gameObject.tag != "Plant")
            {
                if (speed < 0)
                    collision.gameObject.GetComponent<EnemyMove>().movex = -0.14f;
                else
                    collision.gameObject.GetComponent<EnemyMove>().movex = 0.14f;
                speed = 0;
                collision.gameObject.GetComponent<EnemyMove>().EnemyDeath();
            }
            else
            {
                speed = 0;
                Destroy(collision.gameObject);
            }
            
           // Invoke("DestroyFireball", 0.1f);
            
        }
        else if(collision.gameObject.tag=="PIPE"|| collision.gameObject.tag == "Base"|| collision.gameObject.tag == "ENDBASE"|| collision.gameObject.tag == "FLAGBASE"|| collision.gameObject.tag == "WALL")
        {
            fireAnimator.SetBool("DestroyFireball", true);
           // Invoke("DestroyFireball", 0.5f);

        }
        else if(collision.gameObject.tag == "START")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<BoxCollider2D>(), gameObject.GetComponent<BoxCollider2D>());
        }
    }
    private void DestroyFireball()
    {
        Destroy(gameObject);
    }
}
