using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;



public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float LevelLoadDelay = 2f;

     void OnCollisionEnter(Collision other)   // Switch Case
    {
        switch (other.gameObject.tag)  //nelle parentesi mettiamo quello che dobbiamo passare all'array
        {
            case "Friendly":    //Primo caso
                Debug.Log("This thing is friendly");
                break;
            case "Finish":      //Secondo caso
                StartNextLevelSequence();
                break;
            default:            //default si usa per tutto il resto che non abbia un tag
                StartCrashSequence();
                break;
        }
    }

    void StartCrashSequence()
    {   
        //To do add sfx upon crash
        //todo add particle effect upon crash
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", LevelLoadDelay);  //Invoca il ReloadLevel dopo 1 secondoReloadLevel();
    }

    void StartNextLevelSequence()
    {
        GetComponent<Movement>().enabled = false;
        Invoke("NextLevel", LevelLoadDelay);
    }
    void NextLevel()
    {   
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; //Attuale index di cui abbiamo la scena attiva
        int nextSceneIndex = currentSceneIndex + 1; //attuale index + 1, per cambiare scena
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings) //Se next è = al numero totale di scene che abbiamo -->
        {
            nextSceneIndex = 0;  //Reimposta alla prima scena
        }
        SceneManager.LoadScene(nextSceneIndex); //se if non esiste allora carica la prossima scena
    }
    void ReloadLevel()
    {
        // Ottieni il numero della "pagina" (indice) della scena che stai attualmente "leggendo" (attiva)
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        // Carica nuovamente la stessa "pagina" (scena) che stai attualmente "leggendo"
        SceneManager.LoadScene(currentSceneIndex);
    }

   

}
