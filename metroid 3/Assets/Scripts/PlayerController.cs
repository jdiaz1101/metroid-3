using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Author(s): [Strong, Hannah]
 * Date Last Modified: [11/02/2023]
 * Codes for player movement 
 */

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidbodyRef;
    private Vector3 startPos;

    public float speed = 1f;
    public float jumpForce = 10f;

    public bool facingRight = true;

    public float health = 99f;
    public float regEnemyDamage = 15f;
    public float hardEnemyDamage = 35f;

    public bool invincible = false;

    public GameObject laserPrefab;
    public float spawnRate = 1f;
    public bool shootLeft = false;

    public float shootDelay = 1f;
    public float ShootDelay;

    public GameObject HeavyBulletPrefab;
    public GameObject samus;
    public int bullet = 0;
    public bool goingLeft;



    // Start is called before the first frame update
    void Start()
    {
        //gets the rigidbody form the player and stores it as a reference
        rigidbodyRef = GetComponent<Rigidbody>();

        //stores the current position of the player object in the level
        startPos = transform.position;

        ShootDelay = shootDelay;
    }

    // Update is called once per frame
    public void Update()
    {
        

        //if the player is pressing A
        if (Input.GetKey(KeyCode.A))
        {
            //the player moves left
            transform.position += Vector3.left * speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));
            facingRight = false;
        }
        //if the player is pressing D
        if (Input.GetKey(KeyCode.D))
        {
            //the player moves right
            transform.position += Vector3.right * speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
            facingRight = true;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            HandleJump();
        }
        if (Input.GetKey(KeyCode.Return))
        {
            ShootInput();
        }


        if (ShootDelay < shootDelay)
        {
            ShootDelay += Time.deltaTime;
        }


        
        GameOver();
    }





    public void Shoot()
    {
        if (bullet == 1)
        {
            if (samus.transform.rotation.y == 0f)
            {
                goingLeft = false;
                Object.Instantiate(laserPrefab, transform.position, laserPrefab.transform.rotation).GetComponent<laser>().goingLeft = goingLeft;
            }
            else if (samus.transform.rotation.y != 0f)
            {
                goingLeft = true;
                Object.Instantiate(laserPrefab, transform.position, laserPrefab.transform.rotation).GetComponent<laser>().goingLeft = goingLeft;
            }
        }

        if (bullet == 3)
        {
            if (samus.transform.rotation.y == 0f)
            {
                goingLeft = false;
                Object.Instantiate(HeavyBulletPrefab, transform.position, HeavyBulletPrefab.transform.rotation).GetComponent<laser>().goingLeft = goingLeft;
            }
            else if (samus.transform.rotation.y != 0f)
            {
                goingLeft = true;
                Object.Instantiate(HeavyBulletPrefab, transform.position, HeavyBulletPrefab.transform.rotation).GetComponent<laser>().goingLeft = goingLeft;
            }
        }

    }



    public void ShootInput()
    {
        if(ShootDelay >= shootDelay)
        {
            ShootDelay = 0;
            Shoot();
        }
    }


    /*
    public void ShootLaser()
    {
        GameObject laserInstance = Instantiate(laserPrefab, transform.position, transform.rotation);
        laserInstance.GetComponent<laser>().goingLeft = shootLeft;
        
    }
    */

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
                StartCoroutine(Blink());
            }

            if (other.gameObject.tag == "HardEnemy")
            {
                health -= hardEnemyDamage;
                StartCoroutine(Invincible(5));
                StartCoroutine(Blink());
            }

            if (other.gameObject.tag == "Door")
            {
                transform.position = other.gameObject.GetComponent<ExitLevel>().doorPoint.transform.position;
                startPos = transform.position;
            }
        }
        
        if (other.tag == "Heavy")
        {
            bullet++;
            Debug.Log("picked up heavy bullet");
            Destroy(other.gameObject);
        }

        if (other.tag == "JetPack")
        {
            jumpForce += 0.3f;
            Debug.Log("picked up jetpack");
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "ExtraHealth")
        {
            health = 99f;
            health += 100f;
        }

        if (other.gameObject.tag == "HealthPack")
        {
            health = 99f;
            health += 5f;
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

    /*private void PlayerRotation()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            transform.RotateAround(transform.position, transform.up, 180f);
        }
    }*/



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

    

    /// <summary>
    /// Codes for the player blinking after taking damage
    /// </summary>
    /// <returns></returns>
    public IEnumerator Blink()
    {
        for (int index = 0; index < 10; index++)
        {
            if (index % 2 == 0)
            {
                GetComponent<MeshRenderer>().enabled = false;
            }
            else
            {
                GetComponent<MeshRenderer>().enabled = true;
            }
            yield return new WaitForSeconds(.5f);
        }
        GetComponent<MeshRenderer>().enabled = true;
    }
}
