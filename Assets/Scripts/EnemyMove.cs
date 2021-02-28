using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemyMove : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    public float speed = 0.1f;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody.velocity = new Vector2(-speed, rigidBody.velocity.y);
    }
    private void OnCollisionStay2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Destroy(collider.gameObject);
            SceneManager.LoadScene("Game Over");
        }
    }
}
