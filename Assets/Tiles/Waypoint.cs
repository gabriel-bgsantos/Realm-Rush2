using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] GameObject towerPrefab;
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get { return isPlaceable; } } // property being used so another class can get info about this Waypoint class variable

    private void OnMouseDown() {
        if(isPlaceable) {
            Debug.Log(transform.name);
            Instantiate(towerPrefab, transform.position, Quaternion.identity);
            isPlaceable = false; // do not instantiate twice at the same place 
        }
    }
}
