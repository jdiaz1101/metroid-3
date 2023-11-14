using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

/*
 * Author(s): [Strong, Hannah]
 * Date Last Modifiyed: [11/13/2023]
 * codes for item destruction
 */

public class ItemDestruction : MonoBehaviour
{
    /// <summary>
    /// destroys game objects that it is attached to after the player touches it
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "samus")
        {
            Destroy(this.gameObject);
        }
    }
}
