using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int maxHealth = 5;
    [SerializeField] private int Health;
    private GameManager gameManager;
    private float horizontalSpeed = 1f;
    private float jumpForce = 5f;
    public bool isGrounded;
    public bool isDead;
    public bool canMove;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        isGrounded = true;
        canMove = true;
        isDead = false;
        rb = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();
        Health = maxHealth;
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
        Health = Health + amount;

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
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            ChangeHealth(-1);
            Debug.Log($"Ow! New health: {Health}");
        }
    }

}
