using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidDamage : MonoBehaviour 
{
	private bool inAcid;
	public GameObject player;
	PlayerScript playerHealth;
	float timer = 0;
	float acidTimer = 1;
	public int attackDamage;

	// Use this for initialization
	void Start () 
	{
		playerHealth = player.GetComponent<PlayerScript>();
	}

	IEnumerator DoAcidDamage(float damageDuration, int damageCount, float damageAmount)
	{
		inAcid = true;
		int currentCount = 0;
		while (currentCount < damageCount) 
		{
			playerHealth.TakeDamage(attackDamage);
			yield return new WaitForSeconds (damageDuration);
			currentCount++;
		}
		inAcid = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.tag == "Player" && !inAcid) 
		{
			StartCoroutine(DoAcidDamage(acidTimer, 4, attackDamage));
		}
	}
}