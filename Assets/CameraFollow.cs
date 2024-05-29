using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform body1;
    public Transform body2;
    public float zoomFactor = 0.5f; // Regola questo valore per controllare il livello di zoom
    public float minZoom = 5f;
    public float maxZoom = 20f;

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        if (body1 != null && body2 != null)
        {
            Vector3 midpoint = (body1.position + body2.position) / 2f;
            transform.position = new Vector3(midpoint.x, midpoint.y, transform.position.z);

            float distance = Vector3.Distance(body1.position, body2.position);
            float newZoom = Mathf.Lerp(maxZoom, minZoom, distance * zoomFactor);
            cam.orthographicSize = Mathf.Clamp(newZoom, minZoom, maxZoom);
        }
    }
}
