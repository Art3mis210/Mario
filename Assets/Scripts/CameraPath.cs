using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPath : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    public GameObject StartP;
    public GameObject EndP;
    Vector2 Oldpos;
    void Start()
    {
      //  Oldpos = new Vector2(Player.transform.position.x, Player.transform.position.y);
      //  transform.position = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // Vector2 Newpos = new Vector2(Player.transform.position.x-Oldpos.x, Player.transform.position.y);
        // transform.position = new Vector2(transform.position.x+Newpos.x, transform.position.y);
        // Oldpos=Newpos;
       // if(transform.position.x>=StartP.transform.position.x && transform.position.x <= EndP.transform.position.x)
            transform.position = new Vector3(Player.transform.position.x+5 , 0 , transform.position.z);
       // else if(transform.position.x < StartP.transform.position.x)
         //   transform.position = new Vector3(StartP.transform.position.x, 0, transform.position.z);
      //  else if (transform.position.x > EndP.transform.position.x)
         //   transform.position = new Vector3(EndP.transform.position.x, 0, transform.position.z);
    }
}
