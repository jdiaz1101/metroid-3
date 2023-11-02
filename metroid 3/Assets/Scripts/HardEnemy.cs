using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author(s): [Strong, Hannah]
 * Date Last Modified: [11/02/2023]
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
        startingX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyHealth();
        CheckForPlayer();
    }

    private void CheckForPlayer()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.left, out hit, 10))
        {
            if (hit.collider.tag == "Player")
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
        }
        if (Physics.Raycast(transform.position, Vector3.right, out hit, 10))
        {
            if (hit.collider.tag == "Player")
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
        }
        
    }

    private void EnemyHealth()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

}
