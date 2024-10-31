using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI; // Add this for UI functionality

public class GridManager : MonoBehaviour
{
    [Header("Grid and Tilemap")]
    public Grid grid;                       // Reference to the Grid component
    public Tilemap obstacleTilemap;          // Reference to the Tilemap holding obstacles

    [Header("Trail Pieces")]
    public GameObject selectedTrailPiece;    // The trail piece prefab to place
    public GameObject[] trailPiecePrefabs;   // Array of different trail piece prefabs

    void Update()
    {
        // Check for mouse click (left button)
        if (Input.GetMouseButtonDown(0))
        {
            // Get mouse position in world coordinates
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPos.z = 0f; // Ensure the z-coordinate is set to 0 for 2D

            // Convert world position to nearest grid cell position
            Vector3Int cellPosition = grid.WorldToCell(worldPos);

            // Check if the cell position is not an obstacle before placing a trail
            if (!IsObstacle(cellPosition) && selectedTrailPiece != null)
            {
                // Snap the trail piece to the center of the grid cell
                Vector3 snappedPosition = grid.GetCellCenterWorld(cellPosition);

                // Place the trail piece at the snapped position
                PlaceTrail(snappedPosition);
            }
        }
    }

    // Function to check if the grid cell is an obstacle
    bool IsObstacle(Vector3Int position)
    {
        // Check if there is a tile at the given cell in the obstacle tilemap
        TileBase tile = obstacleTilemap.GetTile(position);
        return tile != null; // Returns true if there's an obstacle tile
    }

    // Function to place the trail piece at a given position
    void PlaceTrail(Vector3 position)
    {
        // Instantiate the selected trail piece prefab at the snapped position
        Instantiate(selectedTrailPiece, position, Quaternion.identity);
    }

    // Function called by UI buttons to select a trail piece
    public void SelectTrailPiece(int pieceIndex)
    {
        // Set the selected trail piece based on the index
        selectedTrailPiece = trailPiecePrefabs[pieceIndex];
    }
}
