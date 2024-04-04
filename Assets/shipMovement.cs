using UnityEngine;

public class shipMovement : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public float speed = 5f;
    private int currentIndex = 0;
    private Vector3 targetPosition;
    public Test script;

    void Start()
    {
        bool Turn = script.isTurn;
        if (lineRenderer == null)
        {
            Debug.LogError("LineRenderer reference is missing!");
            return;
        }

        if (lineRenderer.positionCount > 0)
            targetPosition = lineRenderer.GetPosition(currentIndex);
    }

    void Update()
    {
        //I forgot why I added this, im not sure what this part does, it probably just checks for errors
        //by making sure stuff isnt null but I removed it 
        // if(script.Test == null)
        /*
         if (lineRenderer == null || lineRenderer.positionCount == 0)
             return;
         */
        float step = speed * Time.deltaTime;
        //theres a problem with the transform being here, as it moves to the center but it works other times
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
        if (script.isTurn == true)
        {


            //rotation code
            if (lineRenderer != null && lineRenderer.positionCount >= 2)
            {
                // Calculate the targetPosition vector using the positions of the line renderer
                Vector3 targetPosition = lineRenderer.GetPosition(1) - lineRenderer.GetPosition(0);

                // Ensure the targetPosition isn't zero (to avoid errors)
                if (targetPosition != Vector3.zero)
                {
                    // Calculate the angle between the targetPosition and the z-axis
                    float angle = Mathf.Atan2(targetPosition.y, targetPosition.x) * Mathf.Rad2Deg;

                    // Create a rotation only around the z-axis
                    Quaternion rotation = Quaternion.Euler(0f, 0f, angle);

                    // Apply the rotation to the object
                    transform.rotation = rotation;
                }
            }

            //actually moved

            if (transform.position == targetPosition)
            {
                if (currentIndex < lineRenderer.positionCount - 1)
                {

                    currentIndex++;
                    targetPosition = lineRenderer.GetPosition(currentIndex);
                }
                else
                {
                    // If the object reaches the end, you can loop back or handle it as per your requirement.
                    // For example, if you want the object to loop back to the start, uncomment the line below.
                    //currentIndex = 0;
                }
            }

        }

    }

}