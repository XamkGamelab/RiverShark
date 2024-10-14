using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionTrigger : MonoBehaviour
{
    public GameObject levelSection;

    private void OnTriggerEnter(Collider other)
    {
        
        // Kun Collider kohtaa tagin Trigger niin luodaan levelin palanen haluttuun kohtaan.
        if (other.gameObject.CompareTag("Trigger"))
        {
            Instantiate(levelSection, new Vector3(0, 0, -250), Quaternion.identity);
        }
    }
}

