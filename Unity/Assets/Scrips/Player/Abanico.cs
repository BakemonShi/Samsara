﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abanico : MonoBehaviour {

    public GameObject shotBig;
    public GameObject autoAttack;

    private Player player;
    
    public Vector3 intantiateOffset = Vector3.zero;

   
    public void Initialize()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

    }
    public void AttackBig()
    {
       
            GameObject obj = Instantiate(shotBig);
          obj.transform.rotation = Quaternion.Euler(0,0,0);
            obj.transform.position = transform.position+ intantiateOffset;
                    
                         
    }

    public void AutoAttack()
    {
        
        GameObject obj = Instantiate(autoAttack);
        
        obj.transform.rotation = Quaternion.Euler(0,0,0);
        obj.transform.position = transform.position;

        TornadoSmall tornado = obj.GetComponent<TornadoSmall>();
        if (player.isFacingRight) tornado.speed.x = 8;
        else tornado.speed.x = -8;
                        
    }
}
