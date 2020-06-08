using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMasterScript : MonoBehaviour
{
    public HealthBar healthBar;
    public Animator animator;

    public int maxHealth = 100;
    public int damageCount = 30;
    public int currentHealth;
    public int invincibleTime = 2;

    private bool invincible = false;
    private bool isFalling = false;
    private int takedamagecount = 0;

    private GameObject enemies = null;
    private Component[] enemyChildren;

    private AudioSource explosionEffect;
    private AudioSource deathEffect;
    private AudioSource damageEffect;
    private bool deatEffectTrigger = true;

    public Animator crossfadeAnimator;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        enemies = GameObject.Find("Enemies");

        var audio = GetComponents<AudioSource>();
        explosionEffect = audio[0];
        deathEffect = audio[3];
        damageEffect = audio[4];
    }

    void Update()
    {
        enemyChildren = enemies.GetComponentsInChildren<Transform>();

        if (takedamagecount > 0)
        {
            invincible = true;
            StartCoroutine(takeDamage());
            takedamagecount = 0;
        }

        if (gameObject.GetComponent<Rigidbody2D>().velocity.y < 0)
        {
            isFalling = true;
        }
        else
        {
            isFalling = false;
        }

        if (currentHealth <= 0)
        {
            Dead();
            deatEffectTrigger = false;
        }
    }

    void OnCollisionEnter2D(Collision2D CollisionInfo)
    {
        if (!invincible && CollisionInfo.gameObject.tag == "Enemy")
        {
            foreach (Transform child in enemyChildren)
            {
                if (isFalling == true && child.position.y + 1 < gameObject.transform.position.y && Vector3.Distance(child.transform.position, gameObject.transform.position) < 2)
                {
                    explosionEffect.Play();
                    gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 200f));
                    gameObject.GetComponent<CameraShake>().cameraShake();
                    child.GetComponent<EagleController>().dead();
                }
                else if (Vector3.Distance(child.transform.position, gameObject.transform.position) < 2)
                {
                    damageEffect.Play();
                    takedamagecount += 1;
                    Debug.Log("Distance: " + Vector3.Distance(child.transform.position, gameObject.transform.position) + " Eagle Position: " + (child.position.y + 1) + " Player Position: " + gameObject.transform.position.y);
                }
            }
        } else if (CollisionInfo.gameObject.tag == "Enemy")
        {
            foreach (Transform child in enemyChildren)
            {
                if (isFalling == true && child.position.y + 1 < gameObject.transform.position.y && Vector3.Distance(child.transform.position, gameObject.transform.position) < 2)
                {
                    explosionEffect.Play();
                    gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 200f));
                    gameObject.GetComponent<CameraShake>().cameraShake();
                    child.GetComponent<EagleController>().dead();
                }
            }
        }

        if (CollisionInfo.gameObject.tag == "Death Box")
        {
            Dead();
            deatEffectTrigger = false;
        }
    }
	
	IEnumerator takeDamage()
	{
        currentHealth -= damageCount;
		healthBar.SetHealth(currentHealth);
		yield return new WaitForSeconds(invincibleTime);
		invincible = false;
	}

    void Dead()
    {
        if (deatEffectTrigger == true)
        {
            deathEffect.Play();
            var camera = GameObject.Find("Main Camera");
            camera.GetComponent<AudioSource>().Stop();
        }

        currentHealth = 0;
        healthBar.SetMaxHealth(currentHealth);

        animator.SetBool("IsDead", true);
        animator.SetBool("IsJumping", false);
        animator.SetBool("IsCrouching", false);

        gameObject.GetComponent<Rigidbody2D>().simulated = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        gameObject.GetComponent<PlayerMovement>().enabled = false;
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(false);
        
        StartCoroutine(RestartLevel());
    }

    IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(.8f);
        crossfadeAnimator.SetBool("Crossfade Trigger", true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}  
