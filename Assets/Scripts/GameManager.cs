using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private HealthDisplay healthDisplay;
    private GameObject tryAgainButton;


    private void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        healthDisplay = GameObject.Find("HealthBar").GetComponent<HealthDisplay>();
        tryAgainButton = GameObject.Find("TryAgainButton");
        tryAgainButton.SetActive(false);
    }

    public void EndTheGame()
    {
        Debug.Log("EndTheGame called");
        if (playerController.isDead == true)
        {
            //Play death animation
            //Play death sound
            tryAgainButton.SetActive(true);

        }
    }
    public void ResetLevel()
    {
        Debug.Log("ResetLevel called");
        tryAgainButton.SetActive(false);
        playerController.ResetPlayer();
        healthDisplay.DrawHearts();
    }

}
