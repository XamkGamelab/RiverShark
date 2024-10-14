using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;

    private void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    public void EndTheGame()
    {
        Debug.Log("EndTheGame called");
        if (playerController.isDead == true)
        {
            //Play death animation
            //Play death sound
        }
    }
}
