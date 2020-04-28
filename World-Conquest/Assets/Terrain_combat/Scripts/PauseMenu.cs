using System.Linq;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    #region Attributs
    //Pause game variable
    private bool isPaused = false;

    #endregion

    #region Proprietes
    #endregion

    #region Constructeur
    #endregion

    #region Methodes

    void Start()
    {

    }

    // Management of pause menu when press "escape" 
    void Update()
    {
        // If the player presses Esc then the value of isPaused becomes the opposite.
        if (Input.GetKeyDown(KeyCode.Escape))
            isPaused = !isPaused; // Switch each press escape


        if (isPaused)
        {
            Time.timeScale = 0f; // Time stops
            AudioListener.pause = true; // Mute the sound 
        }

        else
        {
            Time.timeScale = 1.0f; // Time starts again
            AudioListener.pause = false; // plays the sound
        }
    }

    void OnGUI()
    {
        if (isPaused)
        {
            //  If the button is pressed then isPaused becomes false so the game resumes.
            if (GUI.Button(new Rect(Screen.width / 2 - 80, Screen.height / 2 - 50, 140, 80), "Continue"))
            {
                isPaused = false;
            }

            // If the button is pressed then the game is completely closed.
            // In the case of the exit button, you have to increase its Y position so that it is lower.
            if (GUI.Button(new Rect(Screen.width / 2 - 80, Screen.height / 2 + 50, 140, 80), "City builder"))
            {
                SceneManager.LoadScene("CityBuilder");
            }

        }
    }

    #endregion
}