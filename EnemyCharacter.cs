using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCharacter : MonoBehaviour
{
    Rigidbody rigidBody;
    bool knockBack;
    Vector3 direction;
    public float timeAttackStart = -1f;
    public float timeDie = -1;

    public float initialX;
    public float initialZ;

    public bool isFollowTarget;

    public NavMeshAgent navMeshAgent;

    float timeSetTarget;
    float timeLastWaypoint;
    float timeToNextWaypoint;

    public Animator animator;


    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        direction = transform.position - transform.forward*1;
        rigidBody = GetComponent<Rigidbody>();
        
        animator = transform.GetComponent<Animator>();
        Vector3 next = NextWaypoint();
        navMeshAgent.SetDestination(next);
       //transform.rotation = Quaternion.LookRotation(new Vector3(0, Random.Range(0f, 90f), 0));
        isFollowTarget = true;
        animator.SetBool("Walking", true);
    }

    // Update is called once per frame
    void Update()
    {

        if (!CharacterHealth.isDead)
        {

            if (HasTarget())
            {
                //this.transform.LookAt(target);
                float distance = Vector3.Distance(transform.position, target.position);

                if (distance <= 2f)
                {
                    Attack();
                }
                if (isFollowTarget)
                {
                    navMeshAgent.SetDestination(target.position);
                    if (distance <= 2f)
                    {
                        isFollowTarget = false;

                        StopNav();
                    }
                }
                else
                {
                    if (distance > 2f)
                    {
                        isFollowTarget = true;
                        StartNav();
                    }
                }
            }
            else
            {
                if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
                {
                    if (Time.timeSinceLevelLoad - timeLastWaypoint > timeToNextWaypoint)
                    {
                        timeLastWaypoint = Time.timeSinceLevelLoad;
                        timeToNextWaypoint = 5f;
                        Vector3 next = NextWaypoint();
                        navMeshAgent.SetDestination(next);
                    }
                }
                if (Time.timeSinceLevelLoad - timeLastWaypoint > 8f)
                {
                    timeLastWaypoint = Time.timeSinceLevelLoad;
                    timeToNextWaypoint = 5f;
                    navMeshAgent.SetDestination(new Vector3(initialX, 0, initialZ));
                }
            }
            /*if (IsDead())
            {
                StopNav();
                if (Time.timeSinceLevelLoad - timeDie > 9f)
                {
                    Respawn();
                }
            }*/
        }
    }


    void Attack()
    {
        if (Time.timeSinceLevelLoad - timeAttackStart > 2f)
        {
            animator.SetBool("Walking", false);
            timeAttackStart = Time.timeSinceLevelLoad;
            animator.SetTrigger("Attack");
        }
        else
        {
            transform.LookAt(target);
        }
                
        
       /* if (HasTarget())
        {
            if (target.GetComponent<Character>().IsDead())
            {
                SetTarget(null);
                StartNav();
            }
        }*/
    }

    

    void StopNav()
    {
        navMeshAgent.isStopped = true;
        navMeshAgent.velocity = Vector3.zero;
        animator.SetBool("Walking", false);
    }

    void StartNav()
    {
        navMeshAgent.isStopped = false;
        animator.SetBool("Walking", true);
    }

    Vector3 NextWaypoint()
    {
        return new Vector3(initialX + Random.Range(-4f, 4f), 0, initialZ + Random.Range(-4f, 4f));

    }

    public bool HasTarget()
    {
        return target != null;
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
        if (target == null)
        {
            isFollowTarget = false;
        }
    }



}
