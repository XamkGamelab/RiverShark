using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField, Range(0f, 10f)]
    private float horizontalSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MoveLeft()
    {
        transform.position += new Vector3(-horizontalSpeed, 0, 0);
    }
    public void MoveRight()
    {
        transform.position += new Vector3(horizontalSpeed, 0, 0);
    }
}
