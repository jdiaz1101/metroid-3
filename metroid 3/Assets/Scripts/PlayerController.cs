using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author(s): [Strong, Hannah]
 * Date Last Modified: [10/26/2023]
 * Codes for player movement 
 */

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidbodyRef;
    private Vector3 startPos;

    public float speed = 10f;
    public float jumpForce = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        //gets the rigidbody form the player and stores it as a reference
        rigidbodyRef = GetComponent<Rigidbody>();

        //stores the current position of the player object in the level
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //if the player is pressing A
        if (Input.GetKey(KeyCode.A))
        {
            //the player moves left
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        //if the player is pressing D
        if (Input.GetKey(KeyCode.D))
        {
            //the player moves right
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            HandleJump();
        }
    }

    /// <summary>
    /// lets the player jump only if they are on the ground and adds physics to jumping
    /// </summary>
    private void HandleJump()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.3f))
        {
            Debug.Log("The player is touching the ground and may jump.");
            rigidbodyRef.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        else
        {
            Debug.Log("The player is in the air and may not jump.");
        }
    }
}
