using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    public static bool isDead;
    private Animator anim;
    [SerializeField]
    private float maxHealth;
    private float currentHealth;
    [SerializeField]
    private string weakness;

    [SerializeField]
    private GameObject treasure;
    
    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    public virtual void DealDamage(float damage, string element)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            this.gameObject.GetComponent<EnemyCharacter>().enabled = false;
            this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
            anim.SetBool("Die", true);
            isDead = true;
            Debug.Log("enemy has died");
            KilledRewards();
            
        }
        if(element == weakness)
        {
            Debug.Log("weakness hit");

        }
    }

    void KilledRewards()
    {
       Rigidbody whatever;
       whatever = Instantiate(treasure, transform.position, treasure.transform.rotation).GetComponent<Rigidbody>();
        whatever.velocity = transform.TransformDirection(-3f,5f,-3f);
    }
}
