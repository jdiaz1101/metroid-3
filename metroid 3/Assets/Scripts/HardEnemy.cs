using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Authors: [Strong, Hannah], [Diaz, Joahan]
 * Date Last Modified: [11/13/2023]
 * Codes for the hard enemy
 */

public class HardEnemy : MonoBehaviour
{
    public float speed;
    private float startingX;

    public int health = 10;

    public bool moveLeft = true;
    
    // Start is called before the first frame update
    void Start()
    {
        //saves the object's starting position so it will stay there until it
        //"sees" the player
        startingX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyHealth();
        CheckForPlayer();
    }

    /// <summary>
    /// Checks to see where the player is standing and then follows it
    /// </summary>
    private void CheckForPlayer()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.left, out hit, 10))
        {
            if (hit.collider.tag == "samus")
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
        }
        if (Physics.Raycast(transform.position, Vector3.right, out hit, 10))
        {
            if (hit.collider.tag == "samus")
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
        }
        
    }

    /// <summary>
    /// Codes for the hard enemy's health and kills it when it runs out
    /// </summary>
    private void EnemyHealth()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "laser")
        {
            health--;
        }
        if (other.tag == "HeavyBullet")
        {
            health -= 3;
        }
    }

}
