using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneEnter : MonoBehaviour
{
    public GameObject thePlayer;
	public GameObject aStar;
    public GameObject cutSceneCam;
    public BoxCollider2D cameraHitbox;

    void Start()
    {
        cutSceneCam.SetActive(false);
        aStar.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D CollisionInfo)
    {
        cameraHitbox.enabled = false;
        cutSceneCam.SetActive(true);
        thePlayer.GetComponent<PlayerMovement>().enabled = false;
        StartCoroutine(FinishCut());
    }

    IEnumerator FinishCut()
    {
        yield return new WaitForSeconds(2);
		aStar.SetActive(true);
		yield return new WaitForSeconds(3);
        thePlayer.GetComponent<PlayerMovement>().enabled = true;
        cutSceneCam.SetActive(false);
    }
}
