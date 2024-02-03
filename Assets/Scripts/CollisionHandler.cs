using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;



public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float LevelLoadDelay = 2f;
    [SerializeField] AudioClip Success;
    [SerializeField] AudioClip Death;

    [SerializeField] ParticleSystem SuccessParticles;
    [SerializeField] ParticleSystem DeathParticles;



    AudioSource audioSource;

    bool isTransitioning = false; //In breve, isTransitioning è come un segnale che dice se l'oggetto sta facendo qualcosa di importante in un dato momento, e durante quel periodo vuoi evitare che si verifichino altre azioni che potrebbero causare problemi o interferenze.
    bool collisionDisable = false;

    void Start() 
    {
     audioSource = GetComponent<AudioSource>();   //Se non facciamo un getcomponent non si può utilizzare nel resto del codice
    }

    void Update()
    {
        RespondToDebugKeys();
    }

    void RespondToDebugKeys()
    {
        if (Input.GetKeyDown(KeyCode.L)) {
            StartNextLevelSequence();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            collisionDisable = !collisionDisable; //toggle collision
        }
    }

     void OnCollisionEnter(Collision other)   // Switch Case
    {
        if (isTransitioning || collisionDisable) //Se IsTransitioning è vero allora riparti in qualsiasi altro caso, vai avanti
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
        DeathParticles.Play(DeathParticles);
        audioSource.PlayOneShot(Death, 0.3f );
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", LevelLoadDelay);  //Invoca il ReloadLevel dopo 1 secondoReloadLevel();
    }


    void StartNextLevelSequence()
    {   
        isTransitioning = true; //nel momento in cui atterro sul landing pad isTransitioning diventa true
        audioSource.Stop();
        SuccessParticles.Play();
        audioSource.PlayOneShot(Success, 0.4f);
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
