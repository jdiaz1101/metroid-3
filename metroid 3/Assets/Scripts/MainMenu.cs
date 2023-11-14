using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Author(s): [Strong, Hannah]
 * Date Last Modified: [11/13/2023]
 * codes for the main menu buttons and scene transitions
 */

public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// loads the game scene
    /// </summary>
    public void Play()
    {
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// lets the player quit the game
    /// </summary>
    public void Quit()
    {
        Debug.Log("You quit the game.");
        Application.Quit();
    }

}
