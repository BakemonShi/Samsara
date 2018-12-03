using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private Player player;
    private GameManager gameManager;

    private HUD hud;


    //
    // Use this for initialization
    void Start()
    {
        gameManager = GetComponent<GameManager>();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

         hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();

    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");


        player.SetHorizontalAxis(hAxis);

        if ((Input.GetButtonDown("Jump")) || (Input.GetButtonDown("X")))
        {
            player.StartJump();
        }
        //correr 
        if (Input.GetButtonDown("Fire3"))
        {
            player.isRunning = true;
        }
        //caminar
        if (Input.GetButtonUp("Fire3"))
        {
            player.isRunning = false;
        }
        if ((Input.GetKeyDown(KeyCode.E)) || (Input.GetButtonDown("R1")))
        {
            player.DashSpeed();
        }
        //dash
        if (Input.GetKeyDown(KeyCode.T))
        {
            gameManager.PressKeyT();
        }
        //GoleFuerte
        if (Input.GetButtonDown("Triangulo"))
        {

        }
        //CambioArma
        if (Input.GetButtonDown("R2"))
        {

        }
        //Cura
        if (Input.GetButtonDown("Redonda"))
        {
            player.Healing();
             if(player.lifePlayer==5)
             {
                hud.OpenFullHP();
             }
        }
    }
}
