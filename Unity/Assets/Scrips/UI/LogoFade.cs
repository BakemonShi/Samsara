using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;


public class LogoFade : MonoBehaviour {

    public Image img;
    public string loadLevel;
    public AudioSource logoFX;


    private void Update()
    {
        
    }

    IEnumerator Start()
    {
        img.canvasRenderer.SetAlpha(0.0f);
        Fadein();
        //logoFX.Play();
        yield return new WaitForSeconds(2.5f);
        FadeOut();
        yield return new WaitForSeconds(2.5f);

        SceneManager.LoadScene(1);

    }

    void Fadein()
    {
        img.CrossFadeAlpha(1.0f, 1.5f, false);
    }
    void FadeOut()
    {
        img.CrossFadeAlpha(0.0f, 2.5f, false);

    }


}

