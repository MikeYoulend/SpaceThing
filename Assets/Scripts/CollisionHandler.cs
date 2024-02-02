using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;



public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float LevelLoadDelay = 2f;
    [SerializeField] AudioClip Success;
    [SerializeField] AudioClip Death;

    AudioSource audioSource;

    bool isTransitioning = false;

    void Start() 
    {
     audioSource = GetComponent<AudioSource>();   //Se non facciamo un getcomponent non si può utilizzare nel resto del codice
    }

     void OnCollisionEnter(Collision other)   // Switch Case
    {
        if (isTransitioning) //Se IsTransitioning è vero allora riparti in qualsiasi altro caso, vai avanti
        {
            return;
        }

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
        isTransitioning = true; //nel momento in cui mi schianto isTransitioning diventa true
        audioSource.Stop();
        //todo add particle effect upon crash
        audioSource.PlayOneShot(Death);
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", LevelLoadDelay);  //Invoca il ReloadLevel dopo 1 secondoReloadLevel();
    }

    void StartNextLevelSequence()
    {   
        isTransitioning = true; //nel momento in cui atterro sul landing pad isTransitioning diventa true
        audioSource.Stop();
        audioSource.PlayOneShot(Success);
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
