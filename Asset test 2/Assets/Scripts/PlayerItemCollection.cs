using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemCollection : MonoBehaviour
{
    public int gemCount = 0;
    private GameObject gemGfx1;
    private GameObject gemGfx2;
    private GameObject gemGfx3;

    void Start()
    {
        gemGfx1 = GameObject.Find("Gem Image 1 Grey");
        gemGfx2= GameObject.Find("Gem Image 2 Grey");
        gemGfx3 = GameObject.Find("Gem Image 3 Grey");
    }

    public void AddJem()
    {
        gemCount += 1;
    }

    void FixedUpdate()
    {
        if (gemCount >= 3)
        {
            gemGfx3.SetActive(false);
        }
        if (gemCount >= 2)
        {
            gemGfx2.SetActive(false);
        }
        if (gemCount >= 1)
        {
            gemGfx1.SetActive(false);
        }
    }   
}
