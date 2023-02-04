using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Vector2Int startCoordinates;
    [SerializeField] Vector2Int destinationCoordinates;

    Node startNode;
    Node destinationNode;
    Node currentSearchNode;

    Queue<Node> frontier = new Queue<Node>(); //FIFO: first in, first out (data structure)
    Dictionary<Vector2Int, Node> reached = new Dictionary<Vector2Int, Node>(); // Used to see whether a node was explored already or not

    Vector2Int[] directions = { Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down };
    GridManager gridManager;
    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();

    private void Awake() {
        gridManager = FindObjectOfType<GridManager>();
        if(gridManager != null) {
            grid = gridManager.Grid;
        }

        startNode = new Node(startCoordinates, true);
        destinationNode = new Node(destinationCoordinates, true);
    }

    void Start()
    {
        //ExploreNeighbors();
        BreadthFirstSearch();
    }

    private void ExploreNeighbors() { //finding the neighbors around you
        List<Node> neighbors = new List<Node>(); // empty list of neighbors (based on Nodes)
        foreach(Vector2Int direction in directions) { // right: 0,1 / left: -1,0 / up: 0,1 / down: 0, -1
            Vector2Int neighborCoords = currentSearchNode.coordinates + direction; // neighbor coordinate is equal the node you're in (node you choose on currentSearchNode) plus 0,1 for ex (your neighbour in the right, so if 0,0 + 0,1 = 0,1 being your right neighbor)
            if(grid.ContainsKey(neighborCoords)) { // it depends on how we are handling the gridSize in the GridManager, if the neighbor coordinate was listed in the gridManager, add it to the neighbors list too
                neighbors.Add(grid[neighborCoords]); // adding the neighbor coordinate (a key from your grid dictionary) to the neighbors list 
                // grid[neighborCoords].isExplored = true; // get this neighbor coordinate an turn isExplored to true (changing its color to yellow)
                // grid[currentSearchNode.coordinates].isPath = true; // get my current node coordinate (getting the current key from our dictionary, that means our current coordinate) and set its isPath to true (changing the current coordinate to orange)
            }
        }
        
        foreach(Node neighbor in neighbors) {
            if(!reached.ContainsKey(neighbor.coordinates) && neighbor.isWalkable) {
                reached.Add(neighbor.coordinates, neighbor);
                frontier.Enqueue(neighbor);
            }
        }
    }

    private void BreadthFirstSearch() {
        bool isRunning = true; //used to break out of the while loop

        frontier.Enqueue(startNode);
        reached.Add(startCoordinates, startNode);

        while(frontier.Count > 0 && isRunning) {
            currentSearchNode = frontier.Dequeue(); // startNode is taken off and then placed as our currentSearchNode
            currentSearchNode.isExplored = true;
            ExploreNeighbors();
            if(currentSearchNode.coordinates == destinationCoordinates) {
                isRunning = false;
            }
        }
    }
}