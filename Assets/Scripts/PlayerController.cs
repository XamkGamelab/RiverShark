using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Rendering.UI;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private HealthDisplay healthDisplay;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private Animator animController;
    
    private Vector3 startPosition;

    public int maxHealth = 5;
    public int Health;
    [SerializeField] private int invisibilityDurationInSeconds = 1;

    private int laneAmount = 5; // amount of lanes 
    private int lane = 3; //which lane the shark is at. Default is 3 (so if there is 5 lanes, the shark starts from the middle lane
    private float horizontalSpeed = 2f;
    private float jumpForce = 6f;

    [SerializeField] private bool isGrounded; //check whether the shark is in air or not
    public bool isDead;
    [SerializeField] private bool canMoveRight;
    [SerializeField] private bool canMoveLeft;
    [SerializeField] private bool isInvinsible = false;

    Rigidbody rb;
    private Material material;
    [SerializeField] private GameObject SharkMeshObject;

    // Start is called before the first frame update
    void Start()
    {
        
        startPosition = transform.position;
        rb = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();
        healthDisplay = GameObject.Find("HealthBar").GetComponent<HealthDisplay>();
        scoreManager = GameObject.Find("Score Manager").GetComponent <ScoreManager>();
        material = SharkMeshObject.GetComponent<Renderer>().material;
        ResetPlayer();
        CheckLane();
    }
    void Update()
    {
        if(!material) return;
        if(!isInvinsible) return;
        
        float target = 6.0f;
        float current = material.GetFloat("_FresnelFloat");
        float change = target - current;
        change *= Time.deltaTime;
        current += change;
        material.SetFloat("_FresnelFloat", current);
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
            animController.SetTrigger("Jump");
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
            collision.gameObject.GetComponent<BoxCollider>().enabled = false;
            if (isInvinsible) return; //If player is invinsible, don't do anything
            ChangeHealth(-1);
            Debug.Log($"Ow! New health: {Health}");
            StartCoroutine(PlayerBecomesInvinsible());
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

    private IEnumerator PlayerBecomesInvinsible()
    {
        isInvinsible = true;
        yield return new WaitForSeconds(invisibilityDurationInSeconds);
        isInvinsible = false;
        material.SetFloat("_FresnelFloat", 0f);
    }
    private void MakePlayerInvisible()
    {
        if (!isInvinsible)
        {
            StartCoroutine(PlayerBecomesInvinsible());
        }
    }
}
