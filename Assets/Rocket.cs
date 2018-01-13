﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour 
{
    [SerializeField]
    float mainThrust = 100f;

    [SerializeField]
    float rcsThrust = 100f;

    Rigidbody rigidBody;
    AudioSource audioSource;

	// Use this for initialization
	void Start () 
    {
		// Get a reference to the RigidBody
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        ProcessInput();
	}

    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                LogToConsole("OK");
                break;
            case "Fuel":
                LogToConsole("Fuel");
                break;
            default:
                LogToConsole("Dead");
                break;
        }
    }

    private void ProcessInput()
    {
        Rotate();
        Thrust();
    }

    private void Rotate()
    {
        rigidBody.freezeRotation = true; // take manual control of rotation

        float rotationThisFrame = rcsThrust * Time.deltaTime;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward * rotationThisFrame);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(-Vector3.forward * rotationThisFrame);
        }

        rigidBody.freezeRotation = false; // resume physics control of rotation
    }

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidBody.AddRelativeForce(Vector3.up * mainThrust);
            if (!audioSource.isPlaying)
                audioSource.Play();
        }
        else
        {
            audioSource.Stop();
        }
    }

    private void LogToConsole(string message)
    {
        print(message);
    }
}