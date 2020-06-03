using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private Animator animator;
    private GameObject player = null;
    private bool trigger = true;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        player = GameObject.Find("Player");
    }

    void OnTriggerEnter2D(Collider2D CollisionInfo)
    {
        if (CollisionInfo.gameObject.name == "Player")
        {
            pickup();
        }
    }

    void pickup()
    {
        if (trigger == true)
        {
            trigger = false;
            player.GetComponent<PlayerItemCollection>().AddJem();
            animator.SetBool("IsPickedUp", true);
            Destroy(gameObject, .3f);
            StartCoroutine(RestartTrigger());
        }
    }

    IEnumerator RestartTrigger()
    {
        yield return new WaitForSeconds(1);
        trigger = true;
    }
}
