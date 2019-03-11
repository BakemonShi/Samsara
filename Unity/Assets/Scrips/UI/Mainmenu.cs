using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour {

    public GameObject menus;
    public GameObject anyKey;

    public GameObject moveTittle;

    public Vector3 speedTranslate;
    public Vector3 speedRotate;

    public float timeCounterMove;
    public bool moveTitle;

    private void Update()
    {
        timeCounterMove += Time.deltaTime;


        if ((Input.GetKeyDown(KeyCode.E))|| (Input.GetButtonDown("Start")))
        {
            OpenMenus();
            moveTitle = true;
            timeCounterMove = 0;
            
        }
        if (moveTitle)
        {
            moveTittle.transform.Translate(speedTranslate * Time.deltaTime);
            moveTittle.transform.Rotate(speedRotate * Time.deltaTime);
        }
        else
            return;
        if(timeCounterMove>1)
        {
            moveTitle = false;
        }
       

    }
    public void PlayGame()
    {
        SceneManager.LoadScene(2);
    }
    public void Info()
    {
        SceneManager.LoadScene(4);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    
     public void OpenMenus()
    {
        menus.SetActive(true);
        anyKey.SetActive(false);
    }
}
