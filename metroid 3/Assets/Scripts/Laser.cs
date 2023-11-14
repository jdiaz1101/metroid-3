using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Authors: [Strong, Hannah], [Diaz, Joahan]
 * Date Last Modified: [11/13/2023]
 * Code for the regular and heavy bullet
 */


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
    public void Update()
    {
        //if the laser should move right, move it right, else move it left
        if (goingLeft)
        {
            transform.position += speed * Vector3.left * Time.deltaTime;
        }
        else
        {
            transform.position += speed * Vector3.right * Time.deltaTime;
        }


    }




    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "RegularEnemy")
        {
            //other.GetComponent<RegularEnemy>().TakeDamage(1);
            Debug.Log("touched enemy");
            Destroy(this.gameObject);
        }


        if (other.tag == "HardEnemy")
        {
            Destroy(this.gameObject);
        }
        
        if (other.tag == "wall")
        {
            Destroy(this.gameObject);
        }
        
    }



}
