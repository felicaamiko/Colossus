using UnityEngine;

public class LineRendererController : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public GameObject ship;
    public GameObject shipUI;

    // Start is called before the first frame update
    void Update()
    {
        if (lineRenderer == null)
        {
            lineRenderer = GetComponent<LineRenderer>();
        }

        // Get positions of ship and shipUI
        Vector3 startPosition = ship.transform.position;
        Vector3 endPosition = shipUI.transform.position;

        // Set positions to line renderer
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, startPosition);
        lineRenderer.SetPosition(1, endPosition);
    }
}
