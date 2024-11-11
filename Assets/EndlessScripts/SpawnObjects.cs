using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    // Array mihin talletetaan kaikki spawnattavat objektit
    public Transform[] allItems;
    // arvottu objekti
    private int whichItem;
    // Arvottu linja
    private float xPos;

    private void Start()
    {
        StartCoroutine(spawnTimer());
        
    }

    IEnumerator spawnTimer()
    {
        // Arvottavien objektien lukum��r� 3kpl 
        whichItem = Random.Range(0, 3);
        xPos = Random.Range(-3f, 3f);

        // Spawnataan arvottu objekti, arvotulle linjalle xPos, korkeutta ja kuinka kauas spawnataan voidaan muuttaa.
        Instantiate(allItems[whichItem], new Vector3(xPos, -0.05f, 0), allItems[whichItem].rotation);
        
        // Spawnataan 3 sekunnin v�lein
        yield return new WaitForSeconds(3);
        // Aloittaa arvonnan alusta.
        StartCoroutine(spawnTimer());
    }
}

