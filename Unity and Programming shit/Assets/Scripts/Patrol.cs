using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Patrol : MonoBehaviour
{
    [SerializeField]
    private Transform[] points;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private FOVEnemy fovEnemy;
    [SerializeField]
    private float minSpeed = 1.5f;
    [SerializeField]
    private float maxSpeed = 2f;
    [SerializeField]
    private AudioSource audioS;
    [SerializeField]
    private InGameUIManager UIManager;
    [SerializeField]
    private bool rotate = false;
    private bool pauseRotation = false;
    [SerializeField]
    private float rotateSpeed = 10f;
    [SerializeField]
    private Animator enemyAnimation;
    [SerializeField]
    private CurrentState enemyState;
    private int destPoint = 0;
    private NavMeshAgent agent;
    private Vector3 lastPlayerPosition;
    private bool followPlayer = false;
    private Vector3 resetPosition = new Vector3(-100, -100, -100);
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.autoBraking = false;
        if (rotate == false)
        {
            GotoNextPoint();
        }
        if (rotate == true)
        {
            agent.destination = points[0].position;
            enemyState = CurrentState.Walking;
        }


    }


    void RotateEnemy()
    {
        
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
    }

    void GotoNextPoint()
    {
        enemyState = CurrentState.Walking;
        if (points.Length == 0)
            return;


        agent.destination = points[destPoint].position;

        destPoint = (destPoint + 1) % points.Length;
    }


    void Update()
    {
        AnimationChecker();
        if (rotate == true && pauseRotation == false && !agent.pathPending && agent.remainingDistance < 0.5f)
        {
            enemyState = CurrentState.Idle;
            Debug.Log("fuck my life");
            agent.updateRotation = false;
            agent.isStopped = true;
            RotateEnemy();

        }
        if (fovEnemy.visibleTargets.Count == 0)
        {

            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                if (lastPlayerPosition != resetPosition)
                {
                    lastPlayerPosition = resetPosition;
                }
                if (agent.speed != minSpeed)
                {
                    followPlayer = false;
                    agent.speed = minSpeed;
                }

                if (rotate == false)
                {
                    GotoNextPoint();
                }
                else if(pauseRotation == true)
                {
                    enemyState = CurrentState.Walking;
                    agent.destination = points[0].position;
                    pauseRotation = false;
                }

            }
        }
        else
        {
            lastPlayerPosition = player.transform.position;
            agent.destination = lastPlayerPosition;
            if (agent.speed != maxSpeed)
            {
                agent.updateRotation = true;
                agent.isStopped = false;
                pauseRotation = true;
                followPlayer = true;
                audioS.Play();
                enemyState = CurrentState.Running;
                agent.speed = maxSpeed;
            }

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && followPlayer == true)
        {
            UIManager.ShowDeadScreen();

        }
    }
    private void AnimationChecker()
    {
        if(enemyState == CurrentState.Idle)
        {
            enemyAnimation.SetBool("isWalking", false);
            enemyAnimation.SetBool("isRunning", false);
        }
        else if(enemyState == CurrentState.Walking)
        {
            enemyAnimation.SetBool("isWalking", true);
            enemyAnimation.SetBool("isRunning", false);
        }
        else if(enemyState == CurrentState.Running)
        {
            enemyAnimation.SetBool("isWalking", false);
            enemyAnimation.SetBool("isRunning", true);
        }
    }
    enum CurrentState
    {
        Idle,
        Walking,
        Running

    }
}




