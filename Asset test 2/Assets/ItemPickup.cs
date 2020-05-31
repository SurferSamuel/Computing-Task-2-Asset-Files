using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
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
        animator.SetBool("IsPickedUp", true);
        Destroy(gameObject, .3f);
    }

}
