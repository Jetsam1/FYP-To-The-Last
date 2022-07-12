using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviourTree;
public class Patrol : Node
{
    Enemies enemy;
    private Transform transform;
    private Transform[] path;
    
    public Patrol(Transform obj,Transform[] waypoints)
    {
        transform = obj;
        path = waypoints;
    }

    private int pathIndex = 0;

    private float pause = 1.5f;
    private float pauseTimer = 0f;
    private bool isPaused = false;

    public override NodeState Eval()
    {
        if(isPaused)
        {
            pauseTimer += Time.deltaTime;
            if(pauseTimer>=pause)
            {
                Debug.Log(isPaused);
                isPaused = false;
            }
        }
        else
        {
            Transform waypoint = path[pathIndex];
            if(Vector3.Distance(transform.position,waypoint.position)<0.01f)
            {
                transform.position = waypoint.position;
                pauseTimer = 0f;
                isPaused = true;

                pathIndex = (pathIndex + 1) % path.Length; // repeats through the path as the last point will lead to the first 
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, waypoint.position, Time.deltaTime * AI.speed);
               
                transform.LookAt(waypoint.position);
            }
        }
        state = NodeState.RUNNING;
        return state;
    }
}
