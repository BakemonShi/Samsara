using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour {

    public GameObject menuPrincipal;
    public GameObject gameMenu;
    public GameObject controles;
    public GameObject optionsMenu;
    public GameObject video;
    
    //public GameObject infoMenu;
    public int menuNum=1;
    private void Start()
    {
        menuPrincipal.SetActive(true);
        gameMenu.SetActive(false);
        optionsMenu.SetActive(false);
       // infoMenu.SetActive(false);
        video.SetActive(false);
        controles.SetActive(false);

    }
    private void Update()
    {
        


    }
    
    public  void StartMenu()
        {
        menuPrincipal.SetActive(true);
        gameMenu.SetActive(false);
        optionsMenu.SetActive(false);
        //infoMenu.SetActive(false);
        video.SetActive(false);

        }
         public  void GameMenu()
        {
        menuPrincipal.SetActive(false);
        gameMenu.SetActive(true);
        optionsMenu.SetActive(false);
        //infoMenu.SetActive(false);
        video.SetActive(false);
        }
         
        public  void NewGame()
        {
        menuPrincipal.SetActive(false);
        gameMenu.SetActive(false);
        optionsMenu.SetActive(false);
        //infoMenu.SetActive(false);
        video.SetActive(true);

        }
        public  void OptionsMenu()
        {
        menuPrincipal.SetActive(false);
        gameMenu.SetActive(false);
        optionsMenu.SetActive(true);
        //infoMenu.SetActive(false);
        video.SetActive(false);

        }
        public  void InfoMenu()
        {
        menuPrincipal.SetActive(false);
        gameMenu.SetActive(false);
        optionsMenu.SetActive(false);
        //infoMenu.SetActive(true);
        video.SetActive(false);

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

    
    
}
