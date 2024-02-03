using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Movement : MonoBehaviour
{   
    //PARAMETERS - for tuning, typically set in the editor
    //CACHE - Referemces fpr readability or speed
    //STATE - private instance (member) variables


    [SerializeField] float rotationForce = 100f;
    [SerializeField] float mainThrust = 100f;
    [SerializeField] AudioClip mainEngine;

    Rigidbody rb;
    AudioSource audioSource;

    

    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody>();
       audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {   
            rb.AddRelativeForce(UnityEngine.Vector3.up * mainThrust * Time.deltaTime); //is a short for (0, 1, 0)
            if(!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(mainEngine, 0.6f );
            } 
        } else 
            {
                audioSource.Stop();
            }
        
    }

    void ProcessRotation()
    {
         if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationForce);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationForce);  //UnityEngine.Vector3.back other way to write 
        }
    }

    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;  //freezing rotation so we can manually rotate
        transform.Rotate(UnityEngine.Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; //unfreezing so the physics system can take over
    }
}
