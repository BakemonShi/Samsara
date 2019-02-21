using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour {


 
    private Player player; 
    public InputManager inputManager;
    public HUD Hud { get; private set; }

    public Vector2 moveCamera;


    public bool isPaused = false;

    public void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player.Initialize(this);

        inputManager = GetComponent<InputManager>();
        inputManager.Initialize(this);

        Hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
    }

   
     void Update()
    {
        if (!isPaused)
        {
            player.MyUpdate();
            inputManager.MyUpdate();
        }
        //else inputManager.ResumeUpdate();

    }

    private void FixedUpdate()
    {
        player.MyFixedUpdate();
    }



}
