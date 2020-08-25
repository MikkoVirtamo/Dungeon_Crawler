using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpKey : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "RoomDetector")
        {
            PlayerInventoryAndStats.SetKey(true);
        }
    }
}
