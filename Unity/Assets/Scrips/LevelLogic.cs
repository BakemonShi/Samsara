using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLogic : MonoBehaviour
{
    public int previousScene;
    public int currentScene;
    public int nextScene;
    
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;

        previousScene = currentScene - 1;
        if (previousScene < 0) previousScene = SceneManager.sceneCountInBuildSettings - 1;

        nextScene = currentScene + 1;
        if (nextScene > SceneManager.sceneCountInBuildSettings - 1) nextScene = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B)) SceneManager.LoadScene(previousScene);
        if (Input.GetKeyDown(KeyCode.R)) SceneManager.LoadScene(currentScene);
        if (Input.GetKeyDown(KeyCode.N)) SceneManager.LoadScene(nextScene);
    }
}
