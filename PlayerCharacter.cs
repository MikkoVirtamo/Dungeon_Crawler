using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCharacter : MonoBehaviour
{

    CharacterController characterController;
    public Animator animator;
    public float speed = 6f;
    public float jumpSpeed = 8f;
    public float gravity = 20f;

    float attackDelay = 1f;
    public float timeAttackStart = -1f;
    public float dashStart = -1f;
    public float dashTimer = 2f;

    Vector3 movement;
    Quaternion rotation = Quaternion.identity;
    private Vector3 movedirection = Vector3.zero;

    public GameObject attackPoint;

    // Start is called before the first frame update
    void Awake()
    {
        animator = transform.GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && Time.time - dashStart > dashTimer)
        {
            speed = 20;
            dashStart = Time.time;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene("BossRoom", LoadSceneMode.Single);
        }
        CheckMovement();
        CheckAttack();
    }


    void CheckAttack()
    {
        if (Time.time - timeAttackStart > attackDelay)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetTrigger("Attack");
                timeAttackStart = Time.time;
            }
        }
    }

    void CheckMovement()
    {
        if(speed > 6)
        {
            speed -= 1f;
        }
        if(speed < 6)
        {
            speed = 6;
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            return;
        }
       
            movedirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            movedirection *= speed;

            

        movement.Set(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        movement.Normalize();

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, movement, 30f * Time.deltaTime, 0f);
        rotation = Quaternion.LookRotation(desiredForward);
        transform.rotation = rotation;


        movedirection.y -= gravity /* Time.deltaTime*/;

        characterController.Move(movedirection * Time.deltaTime);
        animator.SetFloat("Move", movement.magnitude);


        
    }
    void ActivateAttackPoint()
    {
        attackPoint.SetActive(true);
    }

    void DeactivateAttackPoint()
    {
        attackPoint.SetActive(false);
    }
}
