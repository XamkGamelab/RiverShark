using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSection : MonoBehaviour
{


    void Start()
    {
        
    }

    void Update()
    {
        transform.position += new Vector3(0, 0, 10) * Time.deltaTime;
    }
}
