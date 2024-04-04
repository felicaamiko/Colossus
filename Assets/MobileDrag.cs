using UnityEngine;

public class MobileDrag : MonoBehaviour
{
    private Vector3 touchOffset;
    private bool dragging = false;

    private void Update()
    {
        // Check for touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Convert touch position to world position
            Vector3 touchPosWorld = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosWorld.z = 0f; // Set z to 0 to ensure the object stays on the same plane

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    // Check if the touch is within the collider of this object
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPosWorld))
                    {
                        // Calculate offset between touch position and object position
                        touchOffset = transform.position - touchPosWorld;
                        dragging = true;
                    }
                    break;
                case TouchPhase.Moved:
                    // If dragging, update object position based on touch position
                    if (dragging)
                    {
                        transform.position = touchPosWorld + touchOffset;
                    }
                    break;
                case TouchPhase.Ended:
                    // Reset dragging flag
                    dragging = false;
                    break;
            }
        }
    }
}