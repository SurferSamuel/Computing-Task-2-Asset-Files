using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EagleController : MonoBehaviour
{
    private GameObject player = null;
    private bool trigger = true;

    private void Start()
    {
        gameObject.GetComponent<AIDestinationSetter>().enabled = false;

        if (player == null)
        {
            player = GameObject.Find("Player");
        }
    }

    public void dead()
    {
        gameObject.transform.GetChild(0).GetComponent<Animator>().SetBool("IsDead", true);
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        Destroy(gameObject, .5f);
    }

    void FixedUpdate()
    {
        if (trigger == true)
        {
          
            if (Vector3.Distance(gameObject.transform.position, player.transform.position) < 5)
            {
                gameObject.GetComponent<AIDestinationSetter>().enabled = true;
                trigger = false;
            }
        }
    }   
}
