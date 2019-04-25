    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
     
    public Player player;

    //public GameObject floresVidas;
   public GameObject[] vidaMuerte;


    public GameObject pausePanel;

    
   
    

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
      
    }

    public void Update()
    {
        
        deadLife();

    }
    
    
    public void OpenPausePanel()
    {
        pausePanel.SetActive(true);
    }

    public void ClosePausePanel()
    {
        pausePanel.SetActive(false);
    }
    
   
    public void deadLife()
    {

        if (player.lifePlayer == 6)

        {
            vidaMuerte[5].SetActive(false);
            vidaMuerte[4].SetActive(false);
            vidaMuerte[3].SetActive(false);
            vidaMuerte[2].SetActive(false);
            vidaMuerte[1].SetActive(false);
            vidaMuerte[0].SetActive(false);
            //floresVidas[].SetActive(false);//preguntar a SErgio como cojer toda la aaray de gople
        }
        if (player.lifePlayer == 5)

        {
            vidaMuerte[5].SetActive(false);
            vidaMuerte[4].SetActive(false);
            vidaMuerte[3].SetActive(false);
            vidaMuerte[2].SetActive(false);
            vidaMuerte[1].SetActive(false);
            vidaMuerte[0].SetActive(true);
            //floresVidas[].SetActive(false);//preguntar a SErgio como cojer toda la aaray de gople
        }
         if (player.lifePlayer == 4)

        {

            vidaMuerte[5].SetActive(false);
            vidaMuerte[4].SetActive(false);
            vidaMuerte[3].SetActive(false);
            vidaMuerte[2].SetActive(false);
            vidaMuerte[1].SetActive(true);
            vidaMuerte[0].SetActive(true);
        }
         if (player.lifePlayer == 3)

        {
            vidaMuerte[5].SetActive(false);
            vidaMuerte[4].SetActive(false);
            vidaMuerte[3].SetActive(false);
            vidaMuerte[2].SetActive(true);
            vidaMuerte[1].SetActive(true);
            vidaMuerte[0].SetActive(true);
        }
         if (player.lifePlayer == 2)

        {
            vidaMuerte[5].SetActive(false);
            vidaMuerte[4].SetActive(false);
            vidaMuerte[3].SetActive(true);
            vidaMuerte[2].SetActive(true);
            vidaMuerte[1].SetActive(true);
            vidaMuerte[0].SetActive(true);
        }
         if (player.lifePlayer == 1)

        {
            vidaMuerte[5].SetActive(false);
            vidaMuerte[4].SetActive(true);
            vidaMuerte[3].SetActive(true);
            vidaMuerte[2].SetActive(true);
            vidaMuerte[1].SetActive(true);
            vidaMuerte[0].SetActive(true);
        }
       




    }

   
}
