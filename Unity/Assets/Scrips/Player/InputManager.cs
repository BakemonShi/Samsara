using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private Player player;
   
    private GameManager gm;

    private HUD hud;

    public bool isPause;
   
    

   



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
         
                hud.OpenPausePanel();
          
        }

       



    }
    }


