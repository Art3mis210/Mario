using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    public float speed = 10f;
    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        // float v = Input.GetAxis("Vertical");
        if (h != 0)
            sr.flipX = h < 0;
        rigidBody.velocity = new Vector2(h * speed, rigidBody.velocity.y);

    }
}
