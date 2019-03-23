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
    private int destPoint = 0;
    private NavMeshAgent agent;
    private Vector3 lastPlayerPosition;
    private Vector3 resetPosition = new Vector3(-100, -100, -100);
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.autoBraking = false;

        GotoNextPoint();

    }


    void GotoNextPoint()
    {

        if (points.Length == 0)
            return;


        agent.destination = points[destPoint].position;

        destPoint = (destPoint + 1) % points.Length;
    }


    void Update()
    {
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
                    agent.speed = minSpeed;
                }

                GotoNextPoint();
            }
        }
        else
        {
            lastPlayerPosition = player.transform.position;
            agent.destination = lastPlayerPosition;
            if(agent.speed != maxSpeed)
            {
                audioS.Play();
                agent.speed = maxSpeed; 
            }
            Debug.Log("Found player");
        }







    }
}




