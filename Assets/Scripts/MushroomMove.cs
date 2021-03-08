using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomMove : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    public float speed = 50f;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody.velocity = new Vector2(speed * Time.fixedDeltaTime, rigidBody.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "PIPE")
        {
            if (speed != 0)
                speed = -1 * speed;


        }
    }
}
