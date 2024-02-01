using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other)   // Switch Case
    {
        switch (other.gameObject.tag)  //nelle parentesi mettiamo quello che dobbiamo passare all'array
        {
            case "Friendly":    //Primo caso
                Debug.Log("This thing is friendly");
                break;
            case "Finish":      //Secondo caso
                Debug.Log("congrats, yo, you finished!");
                break;
            case "Fuel":        //terzo caso
                Debug.Log("Picked up FUEL");
                break;
            default:            //default si usa per tutto il resto che non abbia un tag
                ReloadLevel();
                break;
        }
    }


    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

}
