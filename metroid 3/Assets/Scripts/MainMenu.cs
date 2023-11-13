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
    public void Play()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Debug.Log("You quit the game.");
        Application.Quit();
    }

}
