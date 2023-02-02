using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Node currentSearchNode;
    Vector2Int[] directions = { Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down };
    GridManager gridManager;
    Dictionary<Vector2Int, Node> grid;

    private void Awake() {
        gridManager = FindObjectOfType<GridManager>();
        if(gridManager != null) {
            grid = gridManager.Grid;
        }
    }

    void Start()
    {
        ExploreNeighbors();
    }

    private void ExploreNeighbors() { //finding the neighbors around you
        List<Node> neighbors = new List<Node>(); // empty list of neighbors (based on Nodes)
        foreach(Vector2Int direction in directions) { // right: 0,1 / left: -1,0 / up: 0,1 / down: 0, -1
            Vector2Int neighborCoords = currentSearchNode.coordinates + direction; // neighbor coordinate is equal the node you're in (node you choose on currentSearchNode) plus 0,1 for ex (your neighbour in the right, so if 0,0 + 0,1 = 0,1 being your right neighbor)
            if(grid.ContainsKey(neighborCoords)) { // it depends on how we are handling the gridSize in the GridManager, if the neighbor coordinate was listed in the gridManager, add it to the neighbors list too
                neighbors.Add(grid[neighborCoords]); // adding the neighbor coordinate (a key from your grid dictionary) to the neighbors list
                grid[neighborCoords].isExplored = true; // get this neighbor coordinate an turn isExplored to true (changing its color to yellow)
                grid[currentSearchNode.coordinates].isPath = true; // get my current node coordinate (getting the current key from our dictionary, that means our current coordinate) and set its isPath to true (changing the current coordinate to orange)
            }

        }
    }
}
