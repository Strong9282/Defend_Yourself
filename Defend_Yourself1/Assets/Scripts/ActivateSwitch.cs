using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSwitch : MonoBehaviour
{
    public GameObject[] bridge;
    public GameObject offSwitch;
    public GameObject onSwitch;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTriggerStay2D(Collider2D collider)
    {
        print("You have entered the switch trigger");

        if (Input.GetKeyDown(KeyCode.E))
        {
            print("You pressed the Space key");
            offSwitch.SetActive(false);
            onSwitch.SetActive(true);
            foreach (GameObject brdg in bridge)
            {
                brdg.SetActive(true);
            }
            
        }
    }
}
