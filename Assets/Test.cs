using UnityEngine;

public class Test : MonoBehaviour
{
    // Declare a boolean variable named isTurn and initialize it to false
    public bool isTurn = false;

    // Function to toggle the value of isTurn
    public void NextTurn()
    {
        // Toggles the value of isTurn
        isTurn = !isTurn;
        Debug.Log("isTurn value after toggling: " + isTurn);
    }
}