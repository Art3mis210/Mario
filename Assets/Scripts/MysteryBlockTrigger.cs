using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysteryBlockTrigger : MonoBehaviour

{
    private BoxCollider2D bCollider2D;
    public SpriteRenderer SR;
    public Sprite empty;
    public Animator An;
    public Rigidbody2D Mush;
    public GameObject Mushroom;

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            SR.sprite = empty;
            Mushroom.SetActive(true);
            An.SetBool("MysteryBlockTrigger", true);
            Invoke("MushroomPOP", 2);
            An.enabled = !An.enabled;
            Destroy(gameObject);
            
            

        }
    }
    private void MushroomPOP()
    {
        An.SetBool("Mushroom out", true);
    }

}
