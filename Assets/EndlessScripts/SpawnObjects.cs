using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    // Array mihin talletetaan kaikki spawnattavat objektit
    public Transform[] allItems;
    // arvottu objekti
    private int whichItem;
    // Esteen arvottu linja
    private float xPos;

    public GameObject Fish;

    //pistekalan arvottu linja
    private float fishPos;

    private void Start()
    {
        StartCoroutine(spawnTimer());
        StartCoroutine(FishSpawnTimer());
    }

    IEnumerator spawnTimer()
    {
        // Spawnataan 3 sekunnin v‰lein
        yield return new WaitForSeconds(3);
        // Arvottavien objektien lukum‰‰r‰ 3kpl
        whichItem = Random.Range(0, 3);
        xPos = Random.Range(-3f, 3f);

        // Spawnataan arvottu objekti, arvotulle linjalle xPos, korkeutta ja kuinka kauas spawnataan voidaan muuttaa.
        Instantiate(allItems[whichItem], new Vector3(xPos, -0.05f, -55), allItems[whichItem].rotation);

        // Aloittaa arvonnan alusta.
        StartCoroutine(spawnTimer());
    }
    IEnumerator FishSpawnTimer()
    {
            // spawnataan 10 sekunnin v‰lein.
            yield return new WaitForSeconds(10);

            fishPos = Random.Range(-3f, 3f);

            GameObject spawnedFish = Instantiate(Fish, new Vector3(fishPos, -0.05f, -55), Quaternion.identity );
        spawnedFish.transform.rotation = Quaternion.identity;
        Debug.Log($"Spawned Fish Rotation: {spawnedFish.transform.rotation.eulerAngles}");
        StartCoroutine(FishSpawnTimer());
    }
}

