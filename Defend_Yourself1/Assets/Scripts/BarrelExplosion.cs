using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelExplosion : MonoBehaviour
{
    public GameObject[] fires;
    public GameObject[] fires2;
    public GameObject[] destructables;

	// Use this for initialization
	void Start ()
    {
	    	
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        foreach (GameObject fire in fires)
        {
            fire.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        Destroy(gameObject);

        foreach (GameObject fire in fires2)
        {
            fire.SetActive(true);
        }

        foreach (GameObject destruct in destructables)
        {
            destruct.SetActive(false);
        }
    }
}
