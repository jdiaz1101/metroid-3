using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Strong, Hannah], [Diaz, Joahan]
 * Date Last Modified: [11/13/2023]
 * Code for the player tracking camera
 */



public class Camera : MonoBehaviour
{

    public GameObject player;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
