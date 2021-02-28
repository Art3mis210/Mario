using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fall : MonoBehaviour
{
    private BoxCollider2D boxCollider2D;
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
            boxCollider2D.isTrigger = true;
        else
        {
            Debug.Log("down");
            Destroy(collider.gameObject);
        }
    }
    private void IsTrigger()
    {
        SceneManager.LoadScene("Game Over");
    }
}
