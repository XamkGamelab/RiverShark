using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public Transform[] allItems;
    private int whichItem;
    private int xPos;

    private void Start()
    {
        StartCoroutine(spawnTimer());

    }

    IEnumerator spawnTimer()
    {
        yield return new WaitForSeconds(3);
        whichItem = Random.Range(0, 4);
        xPos = Random.Range(-1, 2) * 3;
        Instantiate(allItems[whichItem], new Vector3(xPos, .05f, -55), allItems[whichItem].rotation);
        StartCoroutine(spawnTimer());
    }
}

