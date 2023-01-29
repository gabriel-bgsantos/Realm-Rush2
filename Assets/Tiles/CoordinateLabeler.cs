using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.gray;

    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    Waypoint waypoint;

    private void Awake() {
        label = GetComponent<TextMeshPro>();
        DisplayCoordinates(); // show coordinates even before the game starts
        label.enabled = true; // show coordinates setting it as enabled (false you wouldn't see it)
        waypoint = GetComponentInParent<Waypoint>(); // getting the Waypoint component (that is, the class Waypoint in another script)
    }

    // Update is called once per frame
    void Update() {
        if(!Application.isPlaying) { //do this even if the game it's not playing
            DisplayCoordinates();
            UpdateObjectName();
        }

        ColorCoordinates(); // change the color of the text based on if you can place a tower in it or not
        ToggleLabels(); // toggle the text(label) view (on/off - enabled/disabled)
    }

    void DisplayCoordinates() { // display the coordinates of each tile based on its position
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z); // x,z plane (3D)
        label.text = coordinates.x + "," + coordinates.y;
    }

    void UpdateObjectName() {
        transform.parent.name = coordinates.ToString(); 
    }

    void ColorCoordinates() {
        if(waypoint.IsPlaceable) {
            label.color = defaultColor;
        }
        else{
            label.color = blockedColor;
        }
    }

    void ToggleLabels() {
        if(Input.GetKeyDown(KeyCode.C)) {
            label.enabled = !label.IsActive();
        }
    }
}
