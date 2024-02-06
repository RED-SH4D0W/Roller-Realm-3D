using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameManager gameManager;
    private bool isDead;

    public CharacterController controller;
    public Transform cam;

    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public int maxHealth = 5;
    public int currentHealth;

    public HealthBar healthBar;

    static public bool dialogue = false;

    private float _gravity = -9.81f;
    [SerializeField] private float gravityMultiplier = 5.0f;
    private float _velocity;

    private float jumpStrength;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        jumpStrength = 25f;
    }

    // Update is called once per frame
    void Update()
    {
        ApplyGravity();
        if (!dialogue)
        {
            MovePlayer();
            
            if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
            {
                _velocity = jumpStrength;
            }
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(1);
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            if (jumpStrength == 25f)
            {
                jumpStrength = 50f;
            }
            else if (jumpStrength == 50f)
            {
                jumpStrength = 10f;
            }
            else if (jumpStrength == 10f)
            {
                jumpStrength = 25f;
            }
        }

        if (jumpStrength == 25f)
        {
            speed = 40f;
        }
        else if (jumpStrength == 50f)
        {
            speed = 100f;
        }
        else if (jumpStrength == 10f)
        {
            speed = 10f;
        }
    }

    public void MovePlayer()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move((moveDir.normalized * speed + new Vector3(0, _velocity, 0)) * Time.deltaTime); // Apply gravity
        }
        else
        {
            controller.Move(new Vector3(0, _velocity, 0) * Time.deltaTime); // Apply gravity when not moving
        }
    }

    private void ApplyGravity()
    {
        if (controller.isGrounded && _velocity < 0)
        {
            _velocity = 0f; // Reset velocity when grounded
        }
        _velocity += _gravity * gravityMultiplier * Time.deltaTime;
    }



    public void IncreaseHealth(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Ensure health does not exceed maxHealth
        healthBar.SetHealth(currentHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0 && !isDead)
        {
            isDead = true;
            Destroy(gameObject); // Destroy the player when health reaches or falls below zero
            gameManager.gameOver();
        }
    }
}