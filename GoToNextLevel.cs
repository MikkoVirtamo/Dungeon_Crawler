using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNextLevel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "RoomDetector")
        {
            SceneManager.LoadScene("BossRoom", LoadSceneMode.Single);
        }
    }
}
