using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    public float speed = 10f;
    public float jumpSpeed = 4f;
    private SpriteRenderer sr;
    private bool isGrounded;
    public Sprite jump;
    public Sprite stand;
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
        if (h != 0)
            sr.flipX = h < 0;
        rigidBody.velocity = new Vector2(h * speed, rigidBody.velocity.y);
        if (Input.GetKey(KeyCode.Space) && IsGrounded())
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x,jumpSpeed);
            sr.sprite = jump;
            

        }
     

    }
    private bool IsGrounded()
    {
        return isGrounded;
    }
   private void OnCollisionEnter2D(Collision2D collider)
    {
        //   sr.sprite = stand;
        if (collider.gameObject.tag == "Base" || collider.gameObject.tag == "ENDBASE" || collider.gameObject.tag == "PIPE")
        {
            isGrounded = true;
            sr.sprite = stand;
        }
        else
            isGrounded = false;
        if (collider.gameObject.tag=="Plant")
            SceneManager.LoadScene("Game Over");


    }
    private void OnCollisionExit2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Base" || collider.gameObject.tag == "ENDBASE" || collider.gameObject.tag == "PIPE")
            isGrounded = false;
    }


}
