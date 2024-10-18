using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Camera sceneCamera;
    [SerializeField] private LayerMask placementLayerMask; // Ensure this only includes grid objects

    public Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 worldPosition = sceneCamera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, sceneCamera.transform.position.z * -1));
        worldPosition.z = 0; // Ensure it's on the 2D plane
        return worldPosition;
    }

    public Vector3? GetGridPosition()
    {
        Vector3 mouseWorldPosition = GetMouseWorldPosition();
        RaycastHit2D hit = Physics2D.Raycast(mouseWorldPosition, Vector2.zero, Mathf.Infinity, placementLayerMask);

        if (hit.collider != null)
        {
            // Return grid position if hit occurs
            return hit.point;
        }

        return null; // No hit
    }
}
