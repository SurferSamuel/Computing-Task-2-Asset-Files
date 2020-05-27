using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 100;
    public int damageCount = 30;
    public int currentHealth;
	public int invincibleTime = 2;

    public Animator animator;

    public HealthBar healthBar;
    
    public BoxCollider2D boxCollider;
    public CircleCollider2D circleCollider;
    public PlayerMovement CharcterController2D;
    public Rigidbody2D RigidBody2D;
	public GameObject eagle;

    private bool invincible = false;
	private bool isFalling = false;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void OnCollisionEnter2D(Collision2D CollisionInfo)
    {
        if (!invincible)
		{
			if (CollisionInfo.gameObject.name == "Eagle")
			{
				if (isFalling == true)
				{
					gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 400f));
					eagle.GetComponent<EagleController>().dead();
				} else
				{
					invincible = true;
					StartCoroutine(takeDamage());
				}
				
			}
		}	
    }
	
	IEnumerator takeDamage()
	{
		currentHealth -= damageCount;
		healthBar.SetHealth(currentHealth);
		yield return new WaitForSeconds(invincibleTime);
		invincible = false;
	}
	
    void Update()
    {
        if (gameObject.GetComponent<Rigidbody2D>().velocity.y < 0)
		{
			isFalling = true;
		} else
		{
			isFalling = false;
		}
		
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
