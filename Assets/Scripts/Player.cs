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
    private int size;
    public Animator An;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rigidBody = GetComponent<Rigidbody2D>();
        size = 0;
        isGrounded=true;
}
    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");

        if (h == 0)
        {
            An.SetBool("move", false);
            An.enabled = false;
            if (IsGrounded())
                sr.sprite = stand;
        }
        else if (h != 0)
        {
            sr.flipX = h < 0;
            if (IsGrounded())
            {
                An.enabled = true;
                An.SetBool("move", true);

            }
        }
        rigidBody.velocity = new Vector2(h * speed, rigidBody.velocity.y);


        if (Input.GetKey(KeyCode.Space) && IsGrounded())
        {
             An.SetBool("move", false);
             An.enabled = false;
             sr.sprite = jump;
             rigidBody.velocity = new Vector2(rigidBody.velocity.x,jumpSpeed);
             
            

        }
     

    }
    private bool IsGrounded()
    {
        return isGrounded;
    }
   private void OnCollisionEnter2D(Collision2D collider)
    {
        An.enabled = false;
        sr.sprite = stand;
        Debug.Log(collider.gameObject);

        if (collider.gameObject.tag == "Mushroom")
        {
            if (size < 1)
            {
                transform.localScale = new Vector2(2 * transform.localScale.x, 2 * transform.localScale.y);
                size++;
            }
            Destroy(collider.gameObject);   
        }
        if (collider.gameObject.tag == "Base" || collider.gameObject.tag == "ENDBASE" || collider.gameObject.tag == "PIPE")
        {
            isGrounded = true;

        }
        else
        {
            An.SetBool("move", false);
            An.enabled = false;
            isGrounded = false;
        }
 


    }
    private void OnCollisionExit2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Base" || collider.gameObject.tag == "ENDBASE" || collider.gameObject.tag == "PIPE")
            isGrounded = false;
    }


}
