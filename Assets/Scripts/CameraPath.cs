﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPath : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    public bool Underground;
    void Start()
    {
        Underground = false;
    }
    void Update()
    {

            
        if(Underground==true)
        {
            transform.position = new Vector3(2.27f, -10.16f, transform.position.z);
        }
        else
            transform.position = new Vector3(Player.transform.position.x + 5, 0, transform.position.z);

    }
}
