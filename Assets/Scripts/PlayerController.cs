using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private HealthDisplay healthDisplay;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private ScoreManager scoreManager;

    private Vector3 startPosition;

    public int maxHealth = 5;
    public int Health;
    private int laneAmount = 5; // amount of lanes 
    private int lane = 3; //which lane the shark is at. Default is 3 (so if there is 5 lanes, the shark starts from the middle lane
    private float horizontalSpeed = 2f;
    private float jumpForce = 6f;

    public bool isGrounded; //check whether the shark is in air or not
    public bool isDead;
    public bool canMoveRight;
    public bool canMoveLeft;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        
        startPosition = transform.position;
        rb = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();
        healthDisplay = GameObject.Find("HealthBar").GetComponent<HealthDisplay>();
        scoreManager = GameObject.Find("Score Manager").GetComponent <ScoreManager>();
        ResetPlayer();
        CheckLane();
    }
    public void MoveLeft()
    {

        if (canMoveLeft && !isDead)
        {
            transform.position += new Vector3(horizontalSpeed, 0, 0);
            lane--;
            CheckLane();
        }
    }
    public void MoveRight()
    {
         if (canMoveRight && !isDead) 
        {
            transform.position += new Vector3(-horizontalSpeed, 0, 0);
            lane++;
            CheckLane();
        }
    }
    public void Jump()
    {
        if (isGrounded && !isDead) // can't jump if shark is still on air
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
        gameManager.EndTheGame();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("WaterLevel"))
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
        canMoveLeft = true;
        canMoveRight = true;
        isDead = false;
        Health = maxHealth;
        scoreManager.Score = 0;
        transform.position = startPosition;
    }
    private void CheckLane()
    {
        if (lane == 1)
        {
            canMoveLeft = false;
        }
        else if (lane == laneAmount)
        {
            canMoveRight = false;
        }
        else
        {
            canMoveLeft = true;
            canMoveRight = true;
        }
    }
}
