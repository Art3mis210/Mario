using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoopaTrigger : MonoBehaviour
{
    private BoxCollider2D bCollider2D;
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
            Destroy(gameObject.transform.parent.gameObject);
    }

}
