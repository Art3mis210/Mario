using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    private BoxCollider2D bCollider2D;
    public GameObject Parent;
    public GameObject DeadSprite;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
    }
    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            if(Parent.name.Contains("Goomba"))
            {
                Parent.GetComponent<Transform>().localScale = new Vector2(Parent.GetComponent<Transform>().localScale.x, Parent.GetComponent<Transform>().localScale.x - 0.16f);
                Destroy(Parent.GetComponent<EnemyMove>());
                Invoke("DestroyEnemy", 1);
                GameObject.Find("Player").GetComponent<Player>().score += 300;
            }
            else if (Parent.name.Contains("Koopa"))
            {
                Parent.GetComponent<Transform>().localScale = new Vector2(Parent.GetComponent<Transform>().localScale.x, Parent.GetComponent<Transform>().localScale.x - 0.16f);
                Destroy(Parent.GetComponent<EnemyMove>());
                //Parent.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                Invoke("DestroyEnemy", 1);
                GameObject.Find("Player").GetComponent<Player>().score += 300;
            }

            GameObject.Find("Player").GetComponent<Player>().score += 300;
        }
    }
    private void DestroyEnemy()
    {
        Destroy(Parent);
    }

}
