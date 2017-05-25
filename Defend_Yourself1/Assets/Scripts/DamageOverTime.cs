using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOverTime : MonoBehaviour 
{
	public GameObject thePlayer;
	private PlayerScript player;
	public float multipyBy;
	private float time;
	// Use this for initialization
	void Start () 
	{
		player = thePlayer.GetComponent<PlayerScript> ();

        thePlayer = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () 
	{
        //time = (int)Time.deltaTime *multipyBy;
        time = multipyBy * (int)Time.deltaTime;
	}

	void OnTriggerStay2D(Collider2D other)
	{
        

		if (other.tag == "Player") 
		{
            print("Player has entered the ACID trigger!");
            player.TakeDamage ((int)time);
		}
	}
}
