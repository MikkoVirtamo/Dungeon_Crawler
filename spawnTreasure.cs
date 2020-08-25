using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnTreasure : MonoBehaviour
{
    [SerializeField]
    private GameObject treasureChest;
    // Start is called before the first frame update
   public void SpawnTreasureChest()
    {
        Instantiate(treasureChest, transform.position, Quaternion.identity);
    }
}
