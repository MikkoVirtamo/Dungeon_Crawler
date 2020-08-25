using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private CapsuleCollider cap;
    private MeshCollider meshC;
    private MeshRenderer meshR;
    public int currencyWorth;
    // Start is called before the first frame update
    void Start()
    {
        cap = GetComponent<CapsuleCollider>();
        meshC = GetComponent<MeshCollider>();
        meshR = GetComponent<MeshRenderer>();
        StartCoroutine(EnableCap());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag + " entered");
        if(other.tag == "Player" || other.tag == "RoomDetector")
        {
            Debug.Log("picked up coin");
            GameControlStats.Instance.currency += currencyWorth;
            cap.enabled = false;
            meshC.enabled = false;
            meshR.enabled = false;
            StartCoroutine(DestroyThis());
        }
    }

    private IEnumerator EnableCap()
    {
        yield return new WaitForSeconds(2);
        cap.enabled = true;
    }

    private IEnumerator DestroyThis()
    {
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }
}
