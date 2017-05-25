using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDScript : MonoBehaviour
{

    public Collider2D player;
    public Collider2D refuOne;
    public Collider2D refuTwo;
    public Collider2D refuThree;
    public GameObject savedOne;
    public GameObject collectOne;
    public GameObject savedTwo;
    public GameObject collectTwo;
    public GameObject savedThree;
    public GameObject collectThree;

    public bool One = false;
    public bool Two = false;
    public bool Three = false;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        HudDisplay();
	}

    void HudDisplay()
    {
        if (player.IsTouching(refuOne))
        {
            savedOne.SetActive(true);
            One = true;
            collectOne.SetActive(false);
        }

        if (player.IsTouching(refuTwo))
        {
            savedTwo.SetActive(true);
            Two = true;
            collectTwo.SetActive(false);
        }

        if (player.IsTouching(refuThree))
        {
            savedThree.SetActive(true);
            Three = true;
            collectThree.SetActive(false);
        }
    }
}
