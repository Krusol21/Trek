using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    [SerializeField] private GameObject mouseIndicator;
    [SerializeField] private InputManager inputManager;

    private void Update()
    {
        // Always follow the mouse cursor
        Vector3 mousePosition = inputManager.GetMouseWorldPosition();

        // Set the Z-position slightly in front of the grid
        mousePosition.z = -0.1f;

        mouseIndicator.transform.position = mousePosition;

        Vector3? gridPosition = inputManager.GetGridPosition();

        if (gridPosition.HasValue)
        {
            // Snap the indicator to the grid and keep the z offset
            Vector3 snappedPosition = gridPosition.Value;
            snappedPosition.z = -0.1f;  // Maintain the Z offset to avoid overlap
            mouseIndicator.transform.position = snappedPosition;
        }
    }
}
