using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EagleController : MonoBehaviour
{	
	public Transform playerTarget;
	public Transform idleTarget;
		
	public void dead()
	{
		transform.GetChild(0).GetComponent<Animator>().SetBool("IsDead", true);
		gameObject.GetComponent<CircleCollider2D>().enabled = false;
		Destroy(gameObject, .5f);
	}
	
	void Update()
	{
		if (playerTarget.transform.position.x < -11f)
		{	
			gameObject.GetComponent<AIDestinationSetter>().target = idleTarget;
		}
		else
		{
			gameObject.GetComponent<AIDestinationSetter>().target = playerTarget;
		}
	}
}
