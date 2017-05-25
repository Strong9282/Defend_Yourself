using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawScript : MonoBehaviour
{
    public float speed;

    public int attackDamage;

    public GameObject player;
    PlayerScript playerHealth;

    // Use this for initialization
    void Start ()
    {
        playerHealth = player.GetComponent<PlayerScript>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(0, 0, speed * Time.deltaTime);
    }

    public void OnTriggerEnter2D()
    {
        print("Hit the trigger");
        if (playerHealth.curHealth > 0)
        {
            playerHealth.TakeDamage(attackDamage);


        }
    }
}
