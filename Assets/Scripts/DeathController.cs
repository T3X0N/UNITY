using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathController : MonoBehaviour
{
    void Start()
    {
        // Ensure the GameObject has a Collider component and it's set as a trigger
        Collider collider = GetComponent<Collider>();
        if (collider == null)
        {
            collider = GetComponent<BoxCollider>();
            if (collider == null)
            {
                collider = GetComponent<SphereCollider>();
                if (collider == null)
                {
                    collider = GetComponent<CapsuleCollider>();
                }
            }
        }
        
        if (collider != null)
        {
            collider.isTrigger = true;
        }
        else
        {
            Debug.LogWarning("DeathController requires a Collider component. Please add one to this GameObject.");
        }
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is the player
        if (other.GetComponent<PlayerController>() != null)
        {
            // Reset the game
            ResetGame();
        }
    }

    void ResetGame()
    {
        Application.LoadLevel(Application.loadedLevel);  // This is a deprecated method, will change to newer when needed
    }
}

