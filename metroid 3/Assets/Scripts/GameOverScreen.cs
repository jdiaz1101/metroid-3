using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Authors: [Strong, Hannah], [Diaz, Joahan]
 * Date Last Modified: [11/13/2023]
 * codes for the game over screen buttons
 */

public class GameOverScreen : MonoBehaviour
{
    /// <summary>
    /// Lets the player retry the game
    /// </summary>
    public void SwitchScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    /// <summary>
    /// lets the player quit the game
    /// </summary>
    public void QuitGame()
    {
        Debug.Log("You quit the game.");
        Application.Quit();
    }
}
