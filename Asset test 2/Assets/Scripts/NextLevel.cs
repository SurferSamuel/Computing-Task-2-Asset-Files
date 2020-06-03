using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void OnTriggerEnter2D(Collider2D CollisionInfo)
    {
        if (CollisionInfo.gameObject.name == "Player")
        {
            player.GetComponent<PlayerMovement>().enabled = false;
            player.GetComponent<Animator>().SetFloat("Speed", 0f);
            StartCoroutine(RestartLevel());
        }
    }

    // change this to next level
    IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
