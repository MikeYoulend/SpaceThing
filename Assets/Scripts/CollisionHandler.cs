using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other) 
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This thing is friendly");
                break;
            case "Finish": 
                Debug.Log("congrats, yo, you finished!");
                break;
            case "Fuel":
                Debug.Log("Picked up FUEL");
                break;
            default: 
                Debug.Log("Sorry, you blew up");
                break;
        }
    }
}
