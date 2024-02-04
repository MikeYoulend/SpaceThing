using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    UnityEngine.Vector3 startingPosition; //indica la posizione in cui si trova l'oggetto
    [SerializeField] UnityEngine.Vector3 movementVector; //aumenta esponezialmente il range di movimento
    float movementFactor; //Range delimita il movivento tra 0 e 1
    [SerializeField] float period = 2f;


    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position; //dichiaro dove si trova l'oggetto   
    }

    // Update is called once per frame
    void Update()
    {
        float cycles = Time.time / period; //Ciclo di vita, Es. Per arrivare da -2 a più 2, QUANTO TEMPO VOGLIAMO?

        const float tau = Mathf.PI * 2; //Definiamo un tau che sono due Pi greco
        float rawSinWave = Mathf.Sin(cycles * tau); //movimento da -Numero a +Numero

        // La variabile rawSinWave contiene il valore del seno che varia tra -1 e 1.
        // Questa riga trasforma quel valore da [-1, 1] a [0, 1] per essere usato come fattore di movimento.
        movementFactor = (rawSinWave + 1f) / 2f; //+1f serve per farlo partire da 0 invece che -1

       UnityEngine.Vector3 offset = movementVector * movementFactor; //dichiaro quanto si dovrà muovere 
       transform.position = startingPosition + offset; //dichiaro fino a dove arriverà l'oggetto
    }
}
