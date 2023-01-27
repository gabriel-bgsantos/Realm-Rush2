using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();

    // Start is called before the first frame update
    void Start()
    {
        PrintWaypointName();
    }

    void PrintWaypointName () {
        foreach (Waypoint way in path) {
            Debug.Log(way.name);
        }
    }
}
