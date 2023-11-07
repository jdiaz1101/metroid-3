using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyBullet : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "samus")
        {
            PickUp();
        }
    }

    private void PickUp()
    {
        Debug.Log("picked up");
    }

}
