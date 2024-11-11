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
    private float SpawnTime = 3.0f;

    private void Start()
    {
        StartCoroutine(spawnTimer());
        StartCoroutine(UpdateDifficultyTimer());
        
    }

    IEnumerator spawnTimer()
    {
        // Arvottavien objektien lukum��r� 3kpl 
        whichItem = Random.Range(0, 3);
        xPos = Random.Range(-3f, 3f);

        // Spawnataan arvottu objekti, arvotulle linjalle xPos, korkeutta ja kuinka kauas spawnataan voidaan muuttaa.
        Instantiate(allItems[whichItem], new Vector3(xPos, -0.05f, 0), allItems[whichItem].rotation);
        //Instantiate(allItems[whichItem], new Vector3(xPos, -0.05f, 0), allItems[whichItem].rotation);
        
        // Spawnataan 3 sekunnin v�lein
        yield return new WaitForSeconds(SpawnTime);
        // Aloittaa arvonnan alusta.
        StartCoroutine(spawnTimer());
    }
    
    IEnumerator UpdateDifficultyTimer()
    {
        if (SpawnTime >= 0.8f)
        {
            SpawnTime = SpawnTime - 0.3f;
        }
        
        yield return new WaitForSeconds(3);
        StartCoroutine(UpdateDifficultyTimer());
    }
    
}

