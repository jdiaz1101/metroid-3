using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Author(s): [Strong, Hannah]
 * Date Last Modified: [10/31/2023]
 * codes for the game over screen buttons
 */

public class GameOverScreen : MonoBehaviour
{
    /// <summary>
    /// Lets the player retry the game
    /// </summary>
    public void RetryGame()
    {
        SceneManager.LoadScene(0);
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
