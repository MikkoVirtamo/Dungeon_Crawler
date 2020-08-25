using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkforRoom : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "room")
        {
            Destroy(this.gameObject);
        }
    }
}
