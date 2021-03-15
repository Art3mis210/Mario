using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTrigger : MonoBehaviour
{
    public Sprite empty;
    public GameObject coin;
    private bool moveup;
    private bool startAnimation;
    private BoxCollider2D boxcollider;
    public GameObject Box;


    Vector2 oldpos;
    Vector2 newpos;
    void Start()
    {
        moveup = false;
        boxcollider = GetComponent<BoxCollider2D>();
        oldpos = coin.GetComponent<Transform>().position;
        newpos = coin.GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (moveup == true)
        {
            coin.GetComponent<Transform>().position = new Vector2(newpos.x, newpos.y + 0.0095f);
            newpos = coin.GetComponent<Transform>().position;
        }
        if (newpos.y - oldpos.y > 0.5)
        {
            moveup = false;
            GameObject.Find("Player").GetComponent<Player>().score += 100;
            GameObject.Find("Player").GetComponent<Player>().coin += 1;
            Destroy(coin.gameObject);
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Box.GetComponent<SpriteRenderer>().sprite = empty;
            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
            coin.SetActive(true);
            coin.GetComponent<Animator>().enabled = true;
            coin.GetComponent<Animator>().SetBool("Rotate", true);
            moveup = true;
        }
    }
}

