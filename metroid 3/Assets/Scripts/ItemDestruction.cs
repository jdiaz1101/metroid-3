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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "samus")
        {
            Destroy(this.gameObject);
        }
    }
}
