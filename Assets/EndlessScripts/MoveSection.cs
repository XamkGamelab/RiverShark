using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSection : MonoBehaviour
{

    void Update()
    {

        // Pohja/leveli liikkuu pelaajaa kohti. 
        transform.position += new Vector3(0, 0, 10) * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Kun Collider kohtaa colliderin missä tägi Destroy, niin levelin palanen tuhotaan.
        if (other.gameObject.CompareTag("Destroy"))
        {
            Destroy(gameObject);
            Debug.Log("Collider hits object with destroy tag");
        }
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
