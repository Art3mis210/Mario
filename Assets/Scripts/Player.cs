﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    public float speed = 10f;
    public float jumpSpeed = 4f;
    private SpriteRenderer sr;
    private bool isGrounded;
    public Sprite jump0;
    public Sprite stand0;
    public Sprite jump1;
    public Sprite stand1;
    public Sprite jump2;
    public Sprite stand2;
    public int size;
    public Animator An;
    public int score;
    public Text ScoreText;
    public Text CoinCount;
    private BoxCollider2D BoxC2D;
    private Sprite stand;
    private Sprite jump;
    public Animator Flag;
    public GameObject Fireball;
    private Sprite flagpose;
    public Sprite flagpose0;
    public Sprite flagpose1;
    public Sprite flagpose2;
    public Sprite PlayerDeath;
    public int coin;
    public AudioClip CoinSound;
    public AudioClip MushroomOut;
    public AudioClip MushroomTake;
    public AudioClip EnemySound;
    public AudioClip BrickSmash;
    public AudioClip StageClear;
    public AudioClip PowerDown;
    public AudioClip PlayerDeathSound;
    private AudioClip JumpSound;
    public AudioClip Jump0Sound;
    public AudioClip Jump1Sound;
    public AudioClip FireballDeath;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rigidBody = GetComponent<Rigidbody2D>();
        BoxC2D= GetComponent<BoxCollider2D>();
        size = 0;
        isGrounded=true;
        score = 0;
        stand = stand0;
        jump = jump0;
        flagpose=flagpose0;
        coin = 0;
        JumpSound=Jump0Sound;
    }
    // Update is called once per frame
    void Update()
    {
        ScoreText.text ="Score:  "+score;
        CoinCount.text = " X   " + coin;
        float h = Input.GetAxis("Horizontal");
        GameObject.Find("Canvas").transform.GetChild(1).gameObject.SetActive(size >= 0);
        GameObject.Find("Canvas").transform.GetChild(2).gameObject.SetActive(size >= 1);
        GameObject.Find("Canvas").transform.GetChild(3).gameObject.SetActive(size == 2);
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Main Menu");
        }
        if(Input.GetKeyDown(KeyCode.E) && size==2)
        {
              float pos = 0.2f;
              if (sr.flipX == true)
                pos = -0.2f;
              Vector2 FireballPosition = new Vector2(transform.position.x + 1, transform.position.y + 1);
              Instantiate(Fireball, new Vector3(transform.position.x + pos, transform.position.y + 0.05f, transform.position.z), Quaternion.identity);
        }
        
        if (h == 0)
        {
            An.SetBool("move", false);
            An.enabled = false;

            if (isGrounded == true)
            {
                sr.sprite = stand;
            }
        }
        else if (h != 0)
        {
            sr.flipX = h < 0;
            if (isGrounded==true)
            {
                   An.enabled = true;
                   An.SetInteger("size", size);
                   An.SetBool("move", true);
                    
            }

        }
        rigidBody.velocity = new Vector2(h * speed, rigidBody.velocity.y);
        if (Input.GetKey(KeyCode.Space) && isGrounded==true)
        {
                gameObject.GetComponent<AudioSource>().PlayOneShot(JumpSound);
                An.SetBool("move", false);
                An.enabled = false;
                sr.sprite = jump;
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
        }
        
       /* if (Input.GetKeyUp(KeyCode.S))
            sr.sprite = stand;*/
       



    }

    public void ChangeSize(int s)
    {
        if(s==0)
        {
            sr.sprite = stand0;
            stand = stand0;
            jump = jump0;
            flagpose = flagpose0;
            JumpSound = Jump0Sound;
            BoxC2D.size = new Vector2(0.12f, 0.16f);


        }
        else if(s==1)
        {
            sr.sprite = stand1;
            stand = stand1;
            jump = jump1;
            flagpose = flagpose1;
            JumpSound = Jump1Sound;
            BoxC2D.size = new Vector2(0.15f, 0.31f);

        }
        else if (s == 2)
        {
            sr.sprite = stand2;
            stand = stand2;
            jump = jump2;
            flagpose = flagpose2;
            JumpSound = Jump1Sound;
            BoxC2D.size = new Vector2(0.15f, 0.31f);
        }
        if (s > size)
            size++;
        else
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(PowerDown);
            size--;
        }
       // An.SetInteger("size", s);

    }
   private void OnCollisionEnter2D(Collision2D collider)
    {
        An.enabled = false;
        sr.sprite = stand;
        Debug.Log(collider.gameObject);

        if (collider.gameObject.tag == "Mushroom")
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(MushroomTake);
            if (size<=1)
            {
                ChangeSize(size+1);
                An.SetBool("move", false);
            }
            Destroy(collider.gameObject);
        }
        if(collider.gameObject.tag=="END")
        {
           // Destroy(gameObject);
            SceneManager.LoadScene("Game Over");
        }




    }
    private void OnCollisionStay2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Base" || collider.gameObject.tag == "ENDBASE" || collider.gameObject.tag == "PIPE" || collider.gameObject.tag == "Trigger")
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Collectible")
        {
            PlayCoinSound();
            score+=100;
            coin++;
            Destroy(collision.gameObject);
            
        }
        if(collision.gameObject.tag=="FlagPole")
        {
            Destroy(collision.gameObject);
            gameObject.GetComponent<AudioSource>().Stop();
            GameObject.Find("Flag").GetComponent<AudioSource>().Play();
            sr.sprite = flagpose;
            Flag.enabled = true;
            rigidBody.velocity = new Vector2(0, -5);
            score += 1000;
            rigidBody.constraints = RigidbodyConstraints2D.FreezePositionX| RigidbodyConstraints2D.FreezeRotation;
        }
        if (collision.gameObject.tag == "FLAGBASE")
        {
            collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
            rigidBody.constraints = RigidbodyConstraints2D.None;
            rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
            gameObject.GetComponent<AudioSource>().Stop();
            gameObject.GetComponent<AudioSource>().PlayOneShot(StageClear);

        }
       
    }
    private void OnCollisionExit2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Base" || collider.gameObject.tag == "ENDBASE" || collider.gameObject.tag == "PIPE" || collider.gameObject.tag == "Trigger")
            isGrounded = false;
    }
    public void StompEnemy()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(EnemySound);
    }
    public void BrickSmashSound()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(BrickSmash);
    }
    public void MushroomOutSound()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(MushroomOut);
    }
    public void PlayerDeathAnimation()
    {
        An.enabled = false;
        rigidBody.constraints = RigidbodyConstraints2D.FreezePositionX| RigidbodyConstraints2D.FreezeRotation;
        BoxC2D.enabled = false;
        gameObject.GetComponent<AudioSource>().Stop();
        gameObject.GetComponent<AudioSource>().PlayOneShot(PlayerDeathSound);
        sr.sprite = PlayerDeath;
        Destroy(gameObject.GetComponent<Player>());
    }
    public void PlayCoinSound()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(CoinSound);
    }
    public void PlayFireballDeathSound()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(FireballDeath);
    }




}
