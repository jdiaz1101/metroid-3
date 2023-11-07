using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
    public float speed;
    public bool goingLeft;



    private void Start()
    {
        //starts the coroutine when the object 
        //StartCoroutine(DespawnDelay());
    }

    // Update is called once per frame
    void Update()
    {
        //if the laser should move right, move it right, else move it left
        if (goingLeft)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }


    }




    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "RegularEnemy")
        {
            other.GetComponent<RegularEnemy>().TakeDamage(1);
            Debug.Log("touched enemy");
            Destroy(this.gameObject);
        }
        
        if (other.tag == "wall")
        {
            Destroy(this.gameObject);
        }
        
    }



    /*
    private void OnTriggerEnter(Collider other)
    {
        
        if (collision.gameObject.TryGetComponent<RegularEnemy>(out RegularEnemy enemyComponent))
        {
            // do damage here, for example:
            enemyComponent.TakeDamage(1);
        }
        
        if (other.CompareTag("Untagged"))
        {
            Destroy(this.gameObject);
        }

    }
    */

    /*
    /// <summary>
    /// waits for 5 seconds, then destroys itself
    /// </summary>
    /// <returns></returns>
    IEnumerator DespawnDelay()
    {
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }
    */


}
