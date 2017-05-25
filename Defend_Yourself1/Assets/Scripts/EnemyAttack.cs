using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int attackDamage;

    public float damageTime;
    float timer = 0;

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
		
	}

    public void OnTriggerEnter2D(Collider2D collider)
    {
        print("Hit the trigger");
		if (collider.tag == "Player" && playerHealth.curHealth > 0)
        {
//            if (timer >= damageTime)
//            {
//                timer -= damageTime;
               // if (playerHealth.curHealth > 0)
                //{
                    playerHealth.TakeDamage(attackDamage);
                //}
		}

    }

    public void OnTriggerExit()
    {
        
    }
}
