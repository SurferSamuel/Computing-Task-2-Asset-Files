using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneEnter : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject cutSceneCam;
    public GameObject theEagle;
    public BoxCollider2D cameraHitbox;

    void Start()
    {
        cutSceneCam.SetActive(false);
        theEagle.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D CollisionInfo)
    {
        cameraHitbox.enabled = false;
        cutSceneCam.SetActive(true);
        thePlayer.SetActive(false);
        theEagle.SetActive(true);
        StartCoroutine(FinishCut());
    }

    IEnumerator FinishCut()
    {
        yield return new WaitForSeconds(5);
        thePlayer.SetActive(true);
        cutSceneCam.SetActive(false);
    }
}
