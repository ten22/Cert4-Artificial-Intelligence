using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    public Transform waypointParent;
    public float moveSpeed = 2f;
    public float stoppingDistance = 1f;
    
    private Transform[] waypoints;
    private int currentIndex = 1;
    private NavMeshAgent agent;
    void Start()
    {
        //Get Children of waypointParent
        waypoints = waypointParent.GetComponentsInChildren<Transform>();
        //Get reference to NavMeshAgent
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
    }
    void Patrol()
    {
        // 1 - Get the current waypoint
        Transform point = waypoints[currentIndex];
        // 2 - Get distance to waypoint
        float distance = Vector3.Distance(transform.position, point.position);
        // 3 - If close to waypoint
        if(distance < stoppingDistance)
        {
            //     4 - Switch to waypoint
            currentIndex++;
            // 4.1 - Is the current index exceeding array size?
            if(currentIndex >= waypoints.Length)
            {
                currentIndex = 1;
            }
            //      4.2 - Reset current index to 1
        }

        // 5 - translate enemy to waypoint
        // transform.position = Vector3.MoveTowards(transform.position, point.position, moveSpeed * Time.deltaTime);

        //5 - Tell NavMeshAgent it's destination
        agent.SetDestination(point.position);
    }
        
}
