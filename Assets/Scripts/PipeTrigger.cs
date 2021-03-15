using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Plant;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            Plant.SetActive(false);
           // animator.SetBool("PlayerAbove", true);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {

         //   animator.SetBool("PlayerAbove", false);
            Plant.SetActive(true);
         //  animator.enabled = true;
        }
    }
}
