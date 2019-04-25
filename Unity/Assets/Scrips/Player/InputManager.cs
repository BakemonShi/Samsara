using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private Player player;
   
    private GameManager gm;

    private HUD hud;

    public bool isPause;
    public Vector3 speed;
    

   



    //
    // Use this for initialization
    public void Initialize(GameManager gameManager)
    {
        gm = gameManager;

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
      

        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
        isPause = false;
      

        
    }

    // Update is called once per frame
    public void MyUpdate()
    {
      


        if (Input.GetKey(KeyCode.D))
        {
            player.SetHorizontalRight();
            player.isWalking = true;

        }
        if (Input.GetKey(KeyCode.A))
        {
            player.SetHorizontalLeft();
            player.isWalking = true;


        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            player.isWalking = false;

        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            player.isWalking = false;
        }

      


        if ((Input.GetKeyDown(KeyCode.J)) || (Input.GetButtonDown("R1"))) //dash
        {
            player.Dash();
        }
           
          
        if  (Input.GetKeyDown(KeyCode.P))
            {
                Debug.Log("Pulsar Escape");
            if(!isPause)
            {
                Debug.Log("Pausa");
                hud.OpenPausePanel();
                isPause = true;
                Time.timeScale = 0;
            }
             if (isPause)
            {
                
                hud.ClosePausePanel();
                isPause = false;

                Time.timeScale = 1;
            }

            /*   if (!gm.isPaused)
              {
                  hud.OpenPausePanel();
                  //gm.isPaused = true;
                //  Time.timeScale = 0;
              }
                if (gm.isPaused)

              {
                  Time.timeScale = 1;

                  hud.ClosePausePanel();
                  gm.isPaused = false;
              }
              */
        }
            



        }
    }


