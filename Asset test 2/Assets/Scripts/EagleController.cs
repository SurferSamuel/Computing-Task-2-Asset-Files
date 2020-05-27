using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleController : MonoBehaviour
{	
	public void dead()
	{
		transform.GetChild(0).GetComponent<Animator>().SetBool("IsDead", true);
		gameObject.GetComponent<CircleCollider2D>().enabled = false;
		Destroy(gameObject, .5f);
	}
	
}
