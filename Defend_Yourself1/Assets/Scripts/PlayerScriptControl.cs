using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.Networking;

[RequireComponent(typeof(PlayerScript))]
public class PlayerScriptControl : NetworkBehaviour
{
    private PlayerScript m_Character;
    private bool m_Jump;
    private bool m_shoot;
    private bool m_throw;

    public GameObject bulletPrefab;
	private GameObject bullet;
    public Transform bulletSpawn;

	public BulletDamage b_damage;
	public float speed;
    public int bulletAmount;
    public int bulletMax;
    public bool reloading;

    private void Awake()
    {
        m_Character = GetComponent<PlayerScript>();
		b_damage = GetComponent<BulletDamage> ();
        reloading = false;
    }


    private void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }
		bool m_crouch = Input.GetKey(KeyCode.LeftControl);
		bool m_aim = Input.GetKey(KeyCode.F);
		bool m_melee = Input.GetKey(KeyCode.G);
		float h = CrossPlatformInputManager.GetAxis("Horizontal");
		bool m_shoot = Input.GetKey(KeyCode.C);
		bool m_throw = Input.GetKey(KeyCode.V);
		// Pass all parameters to the character control script.
		m_Character.Move(h, m_Jump, m_crouch, m_aim, m_melee, m_shoot, m_throw);
		m_Jump = false;
		if (!m_Jump) {
			// Read the jump input in Update so button presses aren't missed.
			m_Jump = CrossPlatformInputManager.GetButtonDown ("Jump");
		}
		if (Input.GetKeyDown (KeyCode.C)) 
		{
			CmdFire ();
		}        
    }


    private void FixedUpdate()
    {
        // Read the inputs.
       
    }

	[Command]
	void CmdFire()
	{

        if (bulletAmount >= 1)
        {
            bulletAmount = bulletAmount - 1;
            print(bulletAmount);
            bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation); // Instantiate the bullet on the server
                                                                                                        //bullet.GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed,0); // increase the velocity on the bullet after creation
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
            if (m_Character.m_FacingRight == true)
            {
                
                bullet.transform.Rotate(0, 0, 0);
            }
            else
            {
                bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, GetComponent<Rigidbody2D>().velocity.y);
                //speed = -speed;
                bullet.transform.Rotate(0, 180, 0);
            }
            NetworkServer.Spawn(bullet); // Spawn the bullet prefab on the client
            Destroy(bullet, 2.0f);// destroy the bullet after 2 seconds
        }
        else if (!reloading && bulletAmount <= 0)
        {
            //return;
            StartCoroutine(BulletReloadTime());
        }
	}

    IEnumerator BulletReloadTime()
    {
        reloading = true;
        print("wait 5 seconds");
        yield return new WaitForSeconds(5);
        bulletAmount = bulletMax;
        reloading = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Damage")
        {

        }
    }

}

