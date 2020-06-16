using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject cutSceneCam;
    public GameObject explosionEffect;
    public GameObject crates;
    public Animator animator;

    private bool interactable;
    private bool IsPressed;

    private AudioSource explosionEffectAudio;

    void Start()
    {
        animator.enabled = false;
        explosionEffect.SetActive(false);
        cutSceneCam.SetActive(false);
        IsPressed = false;

        var audio = thePlayer.GetComponents<AudioSource>();
        explosionEffectAudio = audio[0];
    }

    void Update()
    {
        if (interactable && IsPressed == false && Input.GetButtonDown("Crouch"))
        {
            interactable = false;
            StartCoroutine(CutSceneStart());
        }
    }

    void OnTriggerEnter2D(Collider2D CollisionInfo)
    {
        interactable = true;
    }

    void OnTriggerExit2D(Collider2D CollisionInfo)
    {
        interactable = false;
    }

    IEnumerator CutSceneStart()
    {
        thePlayer.GetComponent<Animator>().SetFloat("Speed", 0f);
        animator.enabled = true;
        cutSceneCam.SetActive(true);
        thePlayer.GetComponent<PlayerMovement>().enabled = false;
        yield return new WaitForSeconds(2f);
        explosionEffectAudio.Play();
        explosionEffect.SetActive(true);
        thePlayer.GetComponent<CameraShake>().cameraShake(2);
        yield return new WaitForSeconds(0.2f);
        crates.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        explosionEffect.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        cutSceneCam.SetActive(false);
        yield return new WaitForSeconds(2f);
        thePlayer.GetComponent<PlayerMovement>().enabled = true;
        IsPressed = true;
    }
}