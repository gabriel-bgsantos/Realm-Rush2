using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0f, 5f)] float speed = 1f;
    //[SerializeField] float waitTime = 1f;

    void Start()
    {
        FindPath();
        // ReturnToStart();
        StartCoroutine(FollowPath());
    }


    void FindPath() {
        // GameObject[] waypoints = GameObject.findGameObjectsWithTag("Path");

        // foreach(GameObject waypoint in waypoints) {}
        // path.Add(waypoint.GetComponent<Waypoint>());
        // }

        path.Clear();
        GameObject parent = GameObject.FindGameObjectWithTag("Path");
        
        foreach(Transform child in parent.transform) {
            path.Add(child.GetComponent<Waypoint>());
        }
    }

    // void ReturnToStart() {
    //     transform.position = path[0].transform.position; <------ this method is used if the first commented lines of FindPath() is used (so it can start in the right position)
    // }

    IEnumerator FollowPath () {
        foreach (Waypoint way in path) {
            Debug.Log(way.name);
            
            Vector3 startPosition = transform.position;
            Vector3 endPosition = way.transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPosition); // face the end position

            while(travelPercent < 1f) {
                travelPercent += Time.deltaTime * speed;
                // Debug.Log(travelPercent);
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent); // travelPercent goes from 0 to 1, being 0 the startPos and 1 the endPos
                yield return new WaitForEndOfFrame(); //wait till the end of the frame (isn't it obvious?)
            }
    
            // transform.position = way.transform.position;
            // yield return new WaitForSeconds(waitTime);
        }

        Destroy(gameObject);
    }
}
