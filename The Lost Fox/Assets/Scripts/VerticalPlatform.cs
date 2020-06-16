using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatform : MonoBehaviour
{
    private Component[] platformEffector;

    void Start()
    {
        platformEffector = GetComponentsInChildren<PlatformEffector2D>();
    }

    void Update()
    {
        if (Input.GetButtonUp("Crouch"))
        {
            foreach (PlatformEffector2D child in platformEffector)
            {
                child.rotationalOffset = 0f;
            }
        }

        if (Input.GetButtonDown("Crouch"))
        {
            foreach (PlatformEffector2D child in platformEffector)
            {
                child.rotationalOffset = 180f;
            }
        }
    }
}
