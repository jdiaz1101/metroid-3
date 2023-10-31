using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Author(s): [Strong, Hannah]
 * Date Last Modified: [10/31/2023]
 * Codes for player movement 
 */

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidbodyRef;
    private Vector3 startPos;

    public float speed = 10f;
    public float jumpForce = 10f;

    public bool facingRight;

    public float health = 99f;
    public float regEnemyDamage = 15f;
    public float hardEnemyDamage = 35f;

    public bool invincible = false;

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

        GameOver();
    }

    /// <summary>
    /// codes for the scene transition when the player is out of health
    /// </summary>
    private void GameOver()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene(1);
            Debug.Log("Game over");
        }
    }

    //codes for what happens when the player interacts with certian game objects
    //for the not taking damage for 5 seconds maybe do ienumerator thats like 
    //while XXX is happening, dont take damage
    //like the (!waiting) from before?
    private void OnTriggerEnter(Collider other)
    {
        //if you are not invincible
        if (!invincible)
        {
            if (other.gameObject.tag == "RegularEnemy")
            {
                health -= regEnemyDamage;
                StartCoroutine(Invincible(5));
            }

            if (other.gameObject.tag == "HardEnemy")
            {
                health -= hardEnemyDamage;
                StartCoroutine(Invincible(5));
            }
        }
        
        /*if (other.gameObject.tag == "RegularEnemy")
        {
            health += regEnemyDamage;
        }

        if (other.gameObject.tag == "HardEnemy")
        {
            health += hardEnemyDamage;
        }*/
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

    private void PlayerRotation()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.RotateAround(transform.position, transform.up, 180f);
        }
    }



    /// <summary>
    /// makes the player unable to take damage for 5 seconds after getting hit
    /// </summary>
    /// <param name="secondsToWait"></param>
    /// <returns></returns>
    IEnumerator Invincible(float secondsToWait)
    {
        invincible = true;
        yield return new WaitForSeconds(secondsToWait);
        invincible = false;
    }
}
