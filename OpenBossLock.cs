using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBossLock : MonoBehaviour
{
   [SerializeField]
   private GameObject lockRoom;

        private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "RoomDetector" && PlayerInventoryAndStats.GetKey())
        {
            lockRoom.SetActive(false);
        }
    }
}
