using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTreasure : MonoBehaviour
{

    //public List<GameObject> treasures = new List<GameObject>();
    //public GameObject[] treasures;
    
    [SerializeField]
    private GameObject topOfTreasureChest;
    [SerializeField]
    private GameObject bottomOfTreasureChest;
    private GameControlStats gcs;
    private GameObject treasure;
    public void RandomTreasure()
    {
        Debug.Log("Hit treasure chest");
        topOfTreasureChest.SetActive(false);
        bottomOfTreasureChest.SetActive(false);
        Rigidbody whatever;
        //this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        //this.gameObject.GetComponent<BoxCollider>().enabled = false;
        treasure = GameControlStats.Instance.GetTreasure();

        //whatever = Instantiate(treasures[Random.Range(0, treasures.Length - 1)], transform.position, treasures[0].transform.rotation).GetComponent<Rigidbody>();
        //whatever.velocity = transform.TransformDirection(.1f, .1f, .1f);
        whatever = Instantiate(treasure, transform.position, transform.rotation).GetComponent<Rigidbody>();
        whatever.velocity = transform.TransformDirection(.1f, .1f, .1f);
        Destroy(this.gameObject);
    }

}
