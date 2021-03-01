﻿using System.Collections;
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
            Destroy(collider.gameObject);
            SceneManager.LoadScene("Game Over");
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

}
