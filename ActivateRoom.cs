using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateRoom : MonoBehaviour
{
    [SerializeField]
    private GameObject lanterns;
    [SerializeField]
    private GameObject mapPiece;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.tag + " has entered");
        if(other.tag == "RoomDetector")
        {
            lanterns.SetActive(true);
            mapPiece.SetActive(true);
        }
    }
}
