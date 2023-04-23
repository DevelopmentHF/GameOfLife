using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Grid myGrid;

    void Start()
    {
        // Centers the camera on the grid
        transform.position = new Vector3((myGrid.resolution - 1) / 2f, (myGrid.resolution - 1) / 2f, -10f);

        // Zoom out
        if (Camera.main.orthographicSize == myGrid.resolution / 2f)
        {
            Camera.main.orthographicSize *= 1.1f;
        }
    }

}