using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.gray;

    [SerializeField] Color exploredColor = Color.yellow;
    [SerializeField] Color pathColor = new Color(1f, 0.5f, 0f);

    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    //Waypoint waypoint; // creating an object waypoint form the class Waypoint
    GridManager gridManager;


    private void Awake() {
        label = GetComponent<TextMeshPro>();
        DisplayCoordinates(); // show coordinates even before the game starts
        label.enabled = true; // show coordinates setting it as enabled (false you wouldn't see it)
        //waypoint = GetComponentInParent<Waypoint>(); // getting a Waypoint class component (get a component *isPlaceable* in parent *Waypoint Class*)
        gridManager = FindObjectOfType<GridManager>();

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
        if(gridManager == null) { return; } // if did not find out any object GridManager in the Hierarchy

        // if the gridManager isn't null, go there and look at our grid Dictionary and find the node for this instance of our coordinate label (the coord for this tile specifically)
        // the coord for the current tile is already being stored on this "coordinates" variable, so
        Node node = gridManager.GetNode(coordinates); 
        
        if(node == null) { return; }
        
        if(!node.isWalkable) {
            label.color = blockedColor;
        }
        else if(node.isPath) {
            label.color = pathColor;
        }
        else if(node.isExplored) {
            label.color = exploredColor;
        }
        else {
            label.color = defaultColor;
        }

        // if(waypoint.IsPlaceable) {
        //     label.color = defaultColor;
        // }
        // else{
        //     label.color = blockedColor;
        // }
    }

    void ToggleLabels() {
        if(Input.GetKeyDown(KeyCode.C)) {
            label.enabled = !label.IsActive();
        }
    }
}
