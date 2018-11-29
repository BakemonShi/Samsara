    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
     
    public Player player;

    //public GameObject floresVidas;
   public GameObject[] floresVidas;

    public GameObject lostGame;
    public GameObject pressKey;

    public GameObject fullHp;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        CloseKeyPanel();
    }

    private void Update()
    {

        flowersLife();


    }

    public void OpenKeyPanel()
    {
        pressKey.SetActive(true);

    }
    public void CloseKeyPanel()
    {
        pressKey.SetActive(false);
    }

    public void OpenLostPanel()
    {
        lostGame.SetActive(true);
    }

    public void CloseLostPanel()
    {
        lostGame.SetActive(false);
    }
    public void OpenFullHP()
    {
        fullHp.SetActive(true);
    }

    public void CloseFullHP()
    {
        fullHp.SetActive(false);
    }


    public void flowersLife()
    {

        if (player.lifePlayer == 5)

        {
            floresVidas[4].SetActive(true);
            floresVidas[3].SetActive(true);
            floresVidas[2].SetActive(true);
            floresVidas[1].SetActive(true);
            floresVidas[0].SetActive(true);
            //floresVidas[].SetActive(false);//preguntar a SErgio como cojer toda la aaray de gople
        }
        else if (player.lifePlayer == 4)

        {

            floresVidas[4].SetActive(false);
            floresVidas[3].SetActive(true);
            floresVidas[2].SetActive(true);
            floresVidas[1].SetActive(true);
            floresVidas[0].SetActive(true);
        }
        else if (player.lifePlayer == 3)

        {
            floresVidas[4].SetActive(false);
            floresVidas[3].SetActive(false);
            floresVidas[2].SetActive(true);
            floresVidas[1].SetActive(true);
            floresVidas[0].SetActive(true);
        }
        else if (player.lifePlayer == 2)

        {
            floresVidas[4].SetActive(false);
            floresVidas[3].SetActive(false);
            floresVidas[2].SetActive(false);
            floresVidas[1].SetActive(true);
            floresVidas[0].SetActive(true);
        }
        else if (player.lifePlayer == 1)

        {
            floresVidas[4].SetActive(false);
            floresVidas[3].SetActive(false);
            floresVidas[2].SetActive(false);
            floresVidas[1].SetActive(false);
            floresVidas[0].SetActive(true);
        }
        else if (player.lifePlayer == 0)

        {
            OpenLostPanel();
        }




    }

   
}
