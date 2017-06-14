using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BulletDamage : NetworkBehaviour
{
    public float speed = 6;
    public int damageTotal;

    public PlayerScriptControl player;
    public PlayerScript playerHealth;

	// Use this for initialization
	void Start ()
    {
        player = FindObjectOfType<PlayerScriptControl>();
        playerHealth = player.GetComponent<PlayerScript>();

//		if (player.transform.localScale.x < 0)
//		{
//			speed = -speed;
//			transform.Rotate(0, 180, 0);
//		}
	}
	
	// Update is called once per frame
	void Update ()
    {
      // GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
        Destroy(gameObject, 2.0f);
        //var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        //var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        //transform.Rotate(0, x, 0);
        //transform.Translate(0, 0, z);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
  
      if(other.tag == "Player")
        {
            playerHealth.TakeDamage(damageTotal);
            Destroy(gameObject);
        }
    }
}
