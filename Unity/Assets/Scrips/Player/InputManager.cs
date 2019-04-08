using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private Player player;
    public Abanico abanico;
    public AttackSword sword;
    private GameManager gm;

    private HUD hud;

    

    private bool isPause=false;



    //
    // Use this for initialization
    public void Initialize(GameManager gameManager)
    {
        gm = gameManager;

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
      

        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
        
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


        if  ((Input.GetButtonDown("X"))|| (Input.GetKeyDown(KeyCode.Space)))
        {
         //   player.Jump();
        }
       

        if (Input.GetKeyDown(KeyCode.J) || (Input.GetButtonDown("Quadrado")))
        {
            player.AttackBasic();

        }

        if ((Input.GetKeyDown(KeyCode.E)) || (Input.GetButtonDown("R1"))) //dash
        {
            player.Dash();
        }
           
            
          
           
            if (Input.GetButtonDown("Start") || (Input.GetKeyDown(KeyCode.Escape)))
            {
                Debug.Log("Pulsar Escape");
                if (!isPause)
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
            



        }
    }


