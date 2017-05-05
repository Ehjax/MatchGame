/* Sam Cox - 2009 - FrictionPointStudios.com 
 */

using UnityEngine;
using System.Collections;

public class FlythoughController: MonoBehaviour {

    FlythoughWaypoint[] waypoints;

    MyBezier bezier;
    int currentWaypoint = 0;

    public float SecondsForFullLoop = 60f;

	// Use this for initialization
	void Start () {

        Component[] rawArray = transform.parent.GetComponentsInChildren(typeof(FlythoughWaypoint));
        if (rawArray.Length == 0)
        {
            Debug.LogError("You have no 'FlythroughWaypoint' objects defined. Create an empty object at the same level as this and add the FlythoughWaypoint script to it");
        }
        waypoints = new FlythoughWaypoint[rawArray.Length];
        rawArray.CopyTo(waypoints, 0);
        bezier = new MyBezier(waypoints);
        transform.position = waypoints[0].CurrentPosition;
        Vector3 newPosition = bezier.GetPointAtTime(0.01f);

        transform.LookAt(newPosition);
        
    }

	void Update () {

        float currentTime = Time.time % SecondsForFullLoop;
        Vector3 newPosition = bezier.GetPointAtTime(currentTime / SecondsForFullLoop);

        transform.LookAt(newPosition);
        transform.position = newPosition; 

	}

    private Vector3 NextWaypoint()
    {
        if (currentWaypoint + 1 > waypoints.Length - 1)
        {
            return waypoints[0].CurrentPosition;
        }
        else
        {
            return waypoints[currentWaypoint + 1].CurrentPosition;
        }
    }


    void OnDrawGizmosSelected()
    {
        DrawGizmoStuff();
    }

    /// <summary>
    /// This is in a separate method because the waypoints themselves will also call it when selected
    /// </summary>
    public void DrawGizmoStuff()
    {        
        Component[] rawArrayGiz;
        FlythoughWaypoint[] waypointsGiz;

        rawArrayGiz = transform.parent.GetComponentsInChildren(typeof(FlythoughWaypoint));
        waypointsGiz = new FlythoughWaypoint[rawArrayGiz.Length];
        rawArrayGiz.CopyTo(waypointsGiz, 0);

        MyBezier myBezierGiz = new MyBezier(waypointsGiz);

        for (float t = 0; t < 1f; t += 0.001f)
        {
            Gizmos.DrawIcon(myBezierGiz.GetPointAtTime(t), "WaypointHeading.tif");
        }
    }
}
