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
    private int xPos;

    private void Start()
    {
        StartCoroutine(spawnTimer());

    }

    IEnumerator spawnTimer()
    {
        // Spawnataan 3 sekunnin v‰lein
        yield return new WaitForSeconds(3);
        // Arvottavien objektien lukum‰‰r‰ 3kpl
        whichItem = Random.Range(0, 3);
        xPos = Random.Range(-1, 2) * 1;

        // Spawnataan arvottu objekti, arvotulle linjalle xPos, korkeutta ja kuinka kauas spawnataan voidaan muuttaa.
        Instantiate(allItems[whichItem], new Vector3(xPos, 0.5f, -55), allItems[whichItem].rotation);

        // Aloittaa arvonnan alusta.
        StartCoroutine(spawnTimer());
    }
}

