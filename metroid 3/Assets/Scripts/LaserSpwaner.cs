using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpwaner : MonoBehaviour
{
    public GameObject laserPrefab;
    public float spawnRate = 1f;
    public bool shootLeft = false;

    // Start is called before the first frame update
    void Start()
    {
        
        if (Input.GetKey(KeyCode.Mouse0))
        {
            InvokeRepeating("ShootLaser", 0, spawnRate);
            Debug.Log("Mouse 0 ");

        }

    }




            if (Input.GetKey(KeyCode.Return))
        {
            ShootLaser();
    //InvokeRepeating("ShootLaser", 0, spawnRate);


}
public void ShootLaser()
    {
        GameObject laserInstance = Instantiate(laserPrefab, transform.position, transform.rotation);
        laserInstance.GetComponent<laser>().goingLeft = shootLeft;
    }
}
