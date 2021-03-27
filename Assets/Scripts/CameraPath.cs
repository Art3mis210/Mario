using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPath : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    void Update()
    {

            transform.position = new Vector3(Player.transform.position.x+5 , 0 , transform.position.z);

    }
}
