using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float zoomSpeed = 2f;
    [SerializeField] private float minZoom = 5f;
    [SerializeField] private float maxZoom = 20f;

    private Camera cam;

    private void Awake()
    {
        cam = GetComponent<Camera>();
    }

    private void Update()
    {
        // Move the camera with WASD
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float moveY = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(new Vector3(moveX, moveY, 0f), Space.World);

        // Zoom in/out with Q and E
        if (Input.GetKey(KeyCode.Q))
        {
            cam.orthographicSize = Mathf.Clamp(cam.orthographicSize - zoomSpeed * Time.deltaTime, minZoom, maxZoom);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            cam.orthographicSize = Mathf.Clamp(cam.orthographicSize + zoomSpeed * Time.deltaTime, minZoom, maxZoom);
        }
    }
}

