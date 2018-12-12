using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private Player player;
    public Abanico abanico;
    public ComboColor espada;
    private GameManager gameManager;

    private HUD hud;

    public bool isSword;

    private bool isPause=false;



    //
    // Use this for initialization
    void Start()
    {
        gameManager = GetComponent<GameManager>();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
      

        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
        isSword = true;
    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");


        player.SetHorizontalAxis(hAxis);

        if  ((Input.GetButtonDown("X"))|| (Input.GetKeyDown(KeyCode.Space)))
        {
            player.StartJump();
        }
        //correr 
        if (Input.GetButtonDown("Fire3"))
        {
            player.isRunning = true;
        }
       if  (Input.GetKeyDown(KeyCode.J) || (Input.GetButtonDown("Quadrado")))
        {
            if (isSword)
            {
               espada.AttackSwordWeak();
            }
             if(!isSword)
            {
                abanico.AutoAttack();
            }
        }

        //caminar
        if (Input.GetButtonUp("Fire3"))
        {
            player.isRunning = false;
        }
        if ((Input.GetKeyDown(KeyCode.E)) || (Input.GetButtonDown("R1"))) //dash
        {
            player.DashSpeed();
        }
        if ((Input.GetKeyDown(KeyCode.Q)) || (Input.GetButtonDown("L2"))) //dash
        {
            //modo deva
            player.ModeEva();
        }
        //GoleFuerte
        if (Input.GetButtonDown("Triangulo")|| (Input.GetKeyDown(KeyCode.K)))
        {
                if (!isSword)
            {
                abanico.AttackBig();
            }
        }
        //CambioArma
        if (Input.GetButtonDown("R2") || (Input.GetKeyDown(KeyCode.Tab)))
              {
                  player.CambioArma();
                  isSword = !isSword;
            if (isSword)
            {
                hud.OpenSwordPanel();
            }
            else
                hud.CloseSwordPanel();
                    

              }    //Currar por ahora
        if (Input.GetButtonDown("L1")|| (Input.GetKeyDown(KeyCode.O)))
        {
            player.Healing();
            if (player.lifePlayer == 5)
            {
                hud.OpenFullHP();
            }
        }
        if (Input.GetButtonDown("Start") || (Input.GetKeyDown(KeyCode.Escape)))
        {
            Debug.Log("Pulsar Escape");
            if(!isPause)
            {
               
                hud.OpenPausePanel();
                isPause = true;
                Time.timeScale = 0;
            }
            else if (isPause)
                
            {
                Time.timeScale = 1;

                hud.ClosePausePanel();
                isPause = false;
            }

        }
        if (Input.GetButtonDown("Select") || (Input.GetKeyDown(KeyCode.F10)))
        {
            player.GodModeHack();
            Debug.Log("GodMode");
        }



    }
}
