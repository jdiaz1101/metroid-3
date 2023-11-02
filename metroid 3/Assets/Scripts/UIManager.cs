using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*
 * Author(s): [Strong, Hannah]
 * Date Last Modified: [11/02/2023]
 * codes for the games UI
 */

public class UIManager : MonoBehaviour
{
    public PlayerController playerController;
    public TMP_Text hpText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hpText.text = "HP: " + playerController.health.ToString();
    }
}
