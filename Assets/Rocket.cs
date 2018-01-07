using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    Rigidbody rigidBody;
    AudioSource audioSource;

	// Use this for initialization
	void Start () {
		// Get a reference to the RigidBody
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        ProcessInput();
	}

    private void ProcessInput()
    {
        if (Input.GetKey(KeyCode.A))
        {
            print("Rotating left.");
            transform.Rotate(Vector3.forward);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            print("Rotating right.");
            transform.Rotate(-Vector3.forward);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            rigidBody.AddRelativeForce(Vector3.up);
            if(!audioSource.isPlaying)
                audioSource.Play();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (audioSource.isPlaying)                
                audioSource.Stop();
        }
    }
}