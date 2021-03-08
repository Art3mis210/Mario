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
        if (h != 0)
        {
            sr.flipX = h < 0;
            if (IsGrounded())
            {
                An.enabled = true;
                An.SetBool("Move", true);

            }
        }
        if(!IsGrounded())
        {
            sr.sprite = jump;
        }
        if (h == 0)
        {
            An.SetBool("Move", false);
            An.enabled = false;
            if (IsGrounded())
                sr.sprite = stand;
        }
        rigidBody.velocity = new Vector2(h * speed, rigidBody.velocity.y);


        if (Input.GetKey(KeyCode.Space) && IsGrounded())
        {
             An.enabled = false;
             An.SetBool("Move", false);
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
            sr.sprite = stand;
        }
        else
            isGrounded = false;
 


    }
    private void OnCollisionExit2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Base" || collider.gameObject.tag == "ENDBASE" || collider.gameObject.tag == "PIPE")
            isGrounded = false;
    }


}
