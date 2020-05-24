using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 100;
    public int damageCount = 30;
    public int currentHealth;

    public Animator animator;

    public HealthBar healthBar;
    
    public BoxCollider2D boxCollider;
    public CircleCollider2D circleCollider;
    public PlayerMovement CharcterController2D;
    public Rigidbody2D RigidBody2D;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void OnCollisionEnter2D(Collision2D CollisionInfo)
    {
        if (CollisionInfo.gameObject.name == "Eagle")
        {
            takeDamage(damageCount);
        } 
    }

    void takeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            animator.SetBool("IsDead", true);
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsCrouching", false);
            RigidBody2D.simulated = false;
            boxCollider.enabled = false;
            circleCollider.enabled = false;
            CharcterController2D.enabled = false;
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            Destroy(gameObject, 10f);
        }
    }
}  
