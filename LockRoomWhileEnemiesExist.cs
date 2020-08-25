using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockRoomWhileEnemiesExist : MonoBehaviour
{
    [SerializeField]
    private GameObject wall;
    // Start is called before the first frame update
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "enemy")
        {
            wall.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "enemy")
        {
            wall.SetActive(false);
        }
    }
}
