using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu_script : MonoBehaviour
{

    // start button
    public void start() {

        // from scene 0 to scene 1 (in build settings)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    // quit button
    public void quit() {

        Application.Quit();
        Debug.Log("quit game");
        
    }

}
