using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    UnityEngine.Vector3 startingPosition;
    [SerializeField] UnityEngine.Vector3 movementVector;
    [SerializeField] [Range(0,1)] float movementFactor; //Range delimita il movivento tra 0 e 1

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        Debug.Log(startingPosition);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
