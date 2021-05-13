using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class NPCController : MonoBehaviour
{
    public float patrolTimeInSeconds = 10.0f;
    public float agroRange = 5f;
    public Transform[] waypoints;

    private int index;

    // agentSpeed = What the current speed is & what is the component Speed.
    private float speed, agentSpeed;

    private Transform player;
    private Animator anim;
    private NavMeshAgent agent;

    private void Awake()
    {
        //anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        if(agent != null)
        {
            agentSpeed = agent.speed;
        }
        player = GameObject.FindGameObjectWithTag("Player").transform;

        index = Random.Range(0, waypoints.Length);

        InvokeRepeating("Tick", 0, 0.5f);

        if (waypoints.Length > 0)
        {
            InvokeRepeating("Patrol", 0, patrolTimeInSeconds);
        }
        
    }

    void Patrol()
    {
        index = (index == waypoints.Length - 1) ? 0 : index + 1;
    }

    void Tick()
    {
        agent.destination = waypoints[index].position;
        Agro();
    }

    void Agro()
    {
        agent.speed = agentSpeed / 2;

        if (player != null
            && Vector3.Distance(transform.position, player.position) < agroRange)
        {
            agent.destination = player.position;
            agent.speed = agentSpeed;
        }
    }
}
