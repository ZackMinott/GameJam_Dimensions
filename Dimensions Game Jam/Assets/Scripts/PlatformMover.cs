using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))] //adds boxCollider2D to gameObject
[RequireComponent(typeof(Rigidbody2D))] //adds rigidbody2D to gameObject
public class PlatformMover : MonoBehaviour
{

    public Vector3[] localWaypoints; //waypoints that are displayed for visualization of paltform destinations
    Vector3[] globalWaypoints; //waypoint used to move the platforms

    const float skinWidth = .015f;

    public float speed;
    public float waitTime;

    int fromWaypointIndex;
    float percentBetweenWaypoints;

    [Header("Rays Being Fired")]
    public int horizontalRayCount = 4; //Amount of rays being fired horizontally
    public int verticalRayCount = 4; //Amount of rays being fired vertically

    //Calculates spacing between each ray
    float horizontalRaySpacing;
    float verticalRaySpacing;

    BoxCollider2D collider;
    Rigidbody2D rigidbody;
    RaycastOrigins raycastOrigins;
    public CollisionInfo collisions;


    private void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.isKinematic = true;

        globalWaypoints = new Vector3[localWaypoints.Length]; //store all of the waypoints for use
        for (int i = 0; i < localWaypoints.Length; i++)
        {
            globalWaypoints[i] = localWaypoints[i] + transform.position;
        }

        CalculateRaySpacing();
    }

    public void Update()
    {
        UpdateRaycastOrigins();
        Vector3 velocity = CalculatePlatformMovement();

        //movement of the platform
        transform.Translate(velocity);
    }

    Vector3 CalculatePlatformMovement()
    {

        fromWaypointIndex %= globalWaypoints.Length;
        int toWaypointIndex = (fromWaypointIndex + 1) % globalWaypoints.Length;
        float distanceBetweenWaypoints = Vector3.Distance(globalWaypoints[fromWaypointIndex], globalWaypoints[toWaypointIndex]);
        percentBetweenWaypoints += (Time.deltaTime * speed) / distanceBetweenWaypoints;
        percentBetweenWaypoints = Mathf.Clamp01(percentBetweenWaypoints);

        Vector3 newPos = Vector3.Lerp(globalWaypoints[fromWaypointIndex], globalWaypoints[toWaypointIndex], 1f);

        if (percentBetweenWaypoints >= 1) //determines if we have reached a waypoint
        {
            percentBetweenWaypoints = 0;
            fromWaypointIndex++;
            if (fromWaypointIndex >= globalWaypoints.Length - 1)
            {
              fromWaypointIndex = 0;
              System.Array.Reverse(globalWaypoints); //if we have reached the last waypoint, go back in reverse
            }
        }

        return newPos - transform.position;
    }

    void UpdateRaycastOrigins()
    {
        Bounds bounds = collider.bounds; //gets bounds of collider
        bounds.Expand(skinWidth * -2); //shrinks the bounds on all sides by the skinWidth

        //Sets all the bounds of the collider
        raycastOrigins.bottomLeft = new Vector2(bounds.min.x, bounds.min.y);
        raycastOrigins.bottomRight = new Vector2(bounds.max.x, bounds.min.y);
        raycastOrigins.topLeft = new Vector2(bounds.min.x, bounds.max.y);
        raycastOrigins.topRight = new Vector2(bounds.max.x, bounds.max.y);
    }

    void CalculateRaySpacing()
    {
        Bounds bounds = collider.bounds; //gets bounds of collider
        bounds.Expand(skinWidth * -2); //shrinks the bounds on all sides by the skinWidth

        //sets a minimum of at least two rays being fired in both directions
        horizontalRayCount = Mathf.Clamp(horizontalRayCount, 2, int.MaxValue);
        verticalRayCount = Mathf.Clamp(verticalRayCount, 2, int.MaxValue);

        horizontalRaySpacing = bounds.size.y / (horizontalRayCount - 1); //spacing would be entire length of the bounds if min value
        verticalRaySpacing = bounds.size.x / (verticalRayCount - 1);
    }

    //holds data that will not be modified later
    struct RaycastOrigins
    {
        public Vector2 topLeft, topRight;
        public Vector2 bottomLeft, bottomRight;
    }

    public struct CollisionInfo
    {
        public bool above, below;
        public bool left, right;

        public bool climbingSlope;
        public bool descendingSlope;
        public float slopeAngle, slopeAngleOld;
        public Vector3 velocityOld;

        //resets all bools to false
        public void Reset()
        {
            above = below = false;
            left = right = false;
            climbingSlope = false;
            descendingSlope = false;

            slopeAngleOld = slopeAngle;
        }
    }

    private void OnDrawGizmos() //draws waypoints for visualization
    {
        if (localWaypoints != null)
        {
            Gizmos.color = Color.red;
            float size = 0.3f;
            for (int i = 0; i < localWaypoints.Length; i++)
            {
                //if the application is running, will display the waypoints being moved between
                Vector3 globalWaypointPos = (Application.isPlaying) ? globalWaypoints[i] : localWaypoints[i] + transform.position;
                Gizmos.DrawLine(globalWaypointPos - Vector3.up * size, globalWaypointPos + Vector3.up * size);
                Gizmos.DrawLine(globalWaypointPos - Vector3.left * size, globalWaypointPos + Vector3.left * size);
            }
        }
    }

}