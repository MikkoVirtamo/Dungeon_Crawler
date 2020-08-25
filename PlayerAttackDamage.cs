using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackDamage : MonoBehaviour
{
    public LayerMask layer;
    private float radius = .15f;
    public float damage = 1f;
    [SerializeField]
    private string element;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {

        //Collider[] hits = Physics.OverlapBox(gameObject.transform.position, transform.localScale / 2, Quaternion.identity, layer);
        Collider[] hits = Physics.OverlapSphere(transform.position, radius, layer);
        
        if (hits.Length > 0)
        {

            print("touched game object");

            if (hits[0].gameObject.tag == "enemy")
            {
                hits[0].GetComponent<CharacterHealth>().DealDamage(GameControlStats.Instance.attack, element);
            }
            else if(hits[0].gameObject.tag == "interactable")
            {
                Debug.Log("hit an interactable");
            }
            else if(hits[0].gameObject.tag == "treasureChest")
            {
                hits[0].GetComponent<OpenTreasure>().RandomTreasure();
            }
            else if (hits[0].gameObject.tag == "breakable")
            {
                hits[0].GetComponent<breakBarrel>().doBarrelStuff();
            }

            //AddKnockBack(hits[0]);
            gameObject.SetActive(false);
        }
    }

    void AddKnockBack(Collider hit)
    {
        Rigidbody rb = hit.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Debug.Log("rb not null");
            Vector3 direction = hit.transform.position - transform.position;
            direction.y = 0;

            rb.AddForce(direction.normalized * 5, ForceMode.Acceleration);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Check that it is being run in Play Mode, so it doesn't try to draw this in Editor mode
       
            //Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)
            Gizmos.DrawSphere(transform.position, .1f);
    }
}
