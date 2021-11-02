using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public List<Transform> points;
    public Transform platform;
    public Transform pos1;
    public Transform pos2;
    int goalPoint = 0;
    public float speed = 3.0f;

    // Update is called once per frame
    private void Update()
    {
        MoveToNextPoint();
    }
    
    void MoveToNextPoint()
    {
        //Change the position of the platform
        platform.position = Vector2.MoveTowards(platform.position, points[goalPoint].position, Time.deltaTime * speed);
        //Check if we are close to next point
        if(Vector2.Distance(platform.position, points[goalPoint].position) < 0.1f)
        {
            //If player reached point, change it to next point
            if(goalPoint == points.Count - 1)
            {
                goalPoint = 0;
            } else
            {
                goalPoint++;
            }
            //Check if platform reached last point
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos1.position, pos2.position);
    }
}
