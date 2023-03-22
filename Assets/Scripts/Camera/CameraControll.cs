using UnityEngine;

/// <summary>
/// This class is used to control camera position.
/// You can move camera by dragging mouse to the top, bottom, left or right parts of the screen.
/// You can zoom in or out by scrolling mouse middle button. 
/// </summary>

public class CameraControll : MonoBehaviour
{
    [Header("Zooming settings")]
    [SerializeField] private int zoomMultiplier;
    [SerializeField] private int maxZoomOut;
    [SerializeField] private int maxZoomIn;

    [Header("Camera panning")]
    [SerializeField] private float panBorderThickness = 10f;
    [SerializeField] private float panSpeed = 20f;

    private void Start()
    {
        // Lock cursor to game window.
        Cursor.lockState = CursorLockMode.Confined; 
    }

    private void Update()
    {
        CameraMove();
        CameraZoom();
    }

    private void CameraMove()
    {
        Vector3 pos = transform.position;

        // Check if we need to move camera up.
        if (Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            pos.z += panSpeed * Time.deltaTime;
        }

        // Check if we need to move camera down.
        if (Input.mousePosition.y <= panBorderThickness)
        {
            pos.z -= panSpeed * Time.deltaTime;
        }

        // Check if we need to move camera to the right. 
        if (Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            pos.x += panSpeed * Time.deltaTime;
        }

        // Check if we need to move camera to the left. 
        if (Input.mousePosition.x <= panBorderThickness)
        {
            pos.x -= panSpeed * Time.deltaTime;
        }

        // Apply new position. 
        transform.position = pos;
    }

    private void CameraZoom()
    {

        float mouseY = Input.mouseScrollDelta.y * zoomMultiplier;

        // Check if we need to change camera Y position. 
        if (Mathf.Abs(mouseY) > 0)
        {
            transform.position -= new Vector3(0, mouseY, 0);
        }

        // Lock camera zooming in. 
        if (transform.position.y < maxZoomIn)
        {
            transform.position = new Vector3(transform.position.x, maxZoomIn, transform.position.z);
        }

        // Lock camera zooming out. 
        if (transform.position.y > maxZoomOut)
        {
            transform.position = new Vector3(transform.position.x, maxZoomOut, transform.position.z);
        }
    }
}
