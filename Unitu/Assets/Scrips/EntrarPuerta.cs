﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntrarPuerta : MonoBehaviour {
    private GameManager gameManager;
    private HUD hud;

    void Start () {
      //  gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
}
