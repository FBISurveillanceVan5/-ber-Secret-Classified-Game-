﻿using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {

    public Player player; 

    void Start()
    {
        player = gameObject.GetComponentInParent<Player>(); 
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        player.Jumpstate = 0;
    }

    void OnTriggerStay2D(Collider2D col)

    {

        player.Jumpstate = 0; 
    }

    void OnTriggerExit2D(Collider2D col)
    {
        player.Jumpstate = 1; 
    }

    }
