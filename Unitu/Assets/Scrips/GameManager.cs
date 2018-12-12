using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.LuisPedroFonseca.ProCamera2D;

public class GameManager : MonoBehaviour {


    public ProCamera2D cameraPro;
    private Player player; 
    public InputManager inputManager;
    private HUD hud;

    public Vector2 moveCamera;


    public void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        inputManager = GetComponent<InputManager>();
        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
    }

    public void PressKeyT()
    {
        player.transform.Translate(-20, 9, 10);
        cameraPro.MoveCameraInstantlyToPosition(moveCamera);

    }
     void Update()
    {
       
    }

   

}
