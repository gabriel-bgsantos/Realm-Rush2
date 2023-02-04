using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get { return isPlaceable; } } // property being used so another class can get info about this Waypoint class variable

    GridManager gridManager;
    Vector2Int coordinates = new Vector2Int();

    private void Awake() {
        gridManager = FindObjectOfType<GridManager>();
    }

    private void Start() {
        if(gridManager != null) {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);

            if(!isPlaceable) {
                gridManager.BlockNode(coordinates);
            }
        }
    }

    private void OnMouseDown() {
        if(isPlaceable) {
            Debug.Log(transform.name);
            bool isPlaced = towerPrefab.CreateTower(towerPrefab, transform.position); // if isPlaced = true, it means you placed a tower, what means you can't place a tower in the same tile anymore
            isPlaceable = !isPlaced; // if isPlaced = true, it means you CAN NOT place anything else on that tile, that's why we're using !isPlaced
        }
    }
}
