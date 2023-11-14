using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Strong, Hannah], [Diaz, Joahan]
 * Date Last Modified: [11/13/2023]
 * Codes for the regular enemy movement, health and pauses in patrol
 */

public class RegularEnemy : MonoBehaviour
{
    //variables for the left to right movement
    public float travelDistanceRight = 0f;
    public float travelDistanceLeft = 0f;
    public float speed;
    private float startingX;
    private bool movingRight = true;

    //variables for the enemy health
    public float health = 1;

    //variables for the pause before resuming patrol
    //might not be necessary, but I wanted to do it
    public bool waiting = false;
    
    // Start is called before the first frame update
    void Start()
    {
        //this will store the current starting position of the enemy object
        startingX = transform.position.x;
        //health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (!waiting)
        {
            //codes for the enemy patrol movement from left to right
            if (movingRight)
            {
                if (transform.position.x <= startingX + travelDistanceRight)
                {
                    transform.position += Vector3.right * speed * Time.deltaTime;
                }
                else
                {
                    StartCoroutine(Wait(2));
                    movingRight = false;
                }
            }
            else
            {
                if (transform.position.x >= startingX + travelDistanceLeft)
                {
                    transform.position += Vector3.left * speed * Time.deltaTime;
                }
                else
                {
                    StartCoroutine(Wait(2));
                    movingRight = true;
                }
            }

            //checks to see if the enemy should be dead or not
            
        }
        EnemyDeath();
    }

    /// <summary>
    /// destroys the enemy game object if it's health reaches zero
    /// </summary>
    private void EnemyDeath()
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


    /// <summary>
    /// makes the enemy pause at the far left and right of it's patrol
    /// </summary>
    /// <param name="secondsToWait"></param>
    /// <returns></returns>
    IEnumerator Wait(float secondsToWait)
    {
        waiting = true;
        yield return new WaitForSeconds(secondsToWait);
        waiting = false;
    }
}
