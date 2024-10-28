using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int maxHealth = 5;
    public int Health;
    [SerializeField] private HealthDisplay healthDisplay;
    private GameManager gameManager;
    private Vector3 startPosition;
    private float horizontalSpeed = 1f;
    private float jumpForce = 5f;
    public bool isGrounded;
    public bool isDead;
    public bool canMove;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();
        healthDisplay = GameObject.Find("HealthBar").GetComponent<HealthDisplay>();
        ResetPlayer();
    }
    public void MoveLeft()
    {
        if (canMove)
        {
            transform.position += new Vector3(-horizontalSpeed, 0, 0);
        }
    }
    public void MoveRight()
    {
        if (canMove)
        {
            transform.position += new Vector3(horizontalSpeed, 0, 0);
        }
    }
    public void Jump()
    {
        if (isGrounded && canMove)
        {
            isGrounded = false;
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }
    }
    private void ChangeHealth(int amount)
    {
        Health += amount;
        healthDisplay.DrawHearts();

        if (Health <= 0 && isDead != true)
        {
            Death();
        }
    }
    private void Death()
    {
        isDead = true;
        canMove = false;
        Debug.Log("RIP");
        gameManager.EndTheGame();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("Heart")) // get health
        {
            ChangeHealth(1);
        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            ChangeHealth(-1);
            Debug.Log($"Ow! New health: {Health}");
        }
    }

    public void ResetPlayer()
    {
        isGrounded = true;
        canMove = true;
        isDead = false;
        Health = maxHealth;
        transform.position = startPosition;
    }

}
