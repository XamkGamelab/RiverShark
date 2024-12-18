using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    public Sprite Heart;
    public Image[] hearts;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

        for (int i = 0; i < playerController.maxHealth; i++) // Fill hearts array
        {
            hearts[i].sprite = Heart;
        }
    }

    public void DrawHearts() // Draws hearts on the UI depending on player's health
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < playerController.Health)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
