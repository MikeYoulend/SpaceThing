using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    UnityEngine.Vector3 startingPosition;
    [SerializeField] UnityEngine.Vector3 movementVector;
    [SerializeField] UnityEngine.Vector3 movementFactor;

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
