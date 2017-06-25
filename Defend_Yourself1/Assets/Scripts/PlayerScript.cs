using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
//using UnityEngine.Networking.NetworkSystem;


public class PlayerScript : NetworkBehaviour
{
    // My variables below:
	[SyncVar]
    public float maxHealth = 100;
	[SyncVar]
    public float curHealth;
    public float healthBarLength;
	public Slider healthBar;
	bool isDead = false;
    public bool m_throw;
    private bool m_aim;
    public bool m_hurt;
    public bool m_shoot;
    public bool m_melee;
    public bool m_happy;
    public bool m_crouch;
   

    // end my variables

    [SerializeField]
    private float m_MaxSpeed = 10f;                    // The fastest the player can travel in the x axis.
    [SerializeField]
    private float m_JumpForce = 400f;                  // Amount of force added when the player jumps.

    [SerializeField]
    private bool m_AirControl = false;                 // Whether or not a player can steer while jumping;
    [SerializeField]
    private LayerMask m_WhatIsGround;                  // A mask determining what is ground to the character

    private Transform m_GroundCheck;    // A position marking where to check if the player is grounded.
    const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
    private bool m_Grounded;            // Whether or not the player is grounded.
    private Transform m_CeilingCheck;   // A position marking where to check for ceilings
    const float k_CeilingRadius = .01f; // Radius of the overlap circle to determine if the player can stand up
    private Animator m_Anim;            // Reference to the player's animator component.
    private Rigidbody2D m_Rigidbody2D;
    public bool m_FacingRight;  // For determining which way the player is currently facing.
	public PlayerScriptControl playScriptctrl;

    void Start()
    {

    }

    private void Awake()
    {
        // Setting up references.
        m_GroundCheck = transform.Find("GroundCheck");
        m_CeilingCheck = transform.Find("CeilingCheck");
        m_Anim = GetComponent<Animator>();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        // my references
        curHealth = maxHealth;
        healthBar.value = CalculateHealth();
    }

    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }


        healthBar.value = CalculateHealth();
		//print (isDead);
		Death ();
        if (curHealth <= 0 && !isDead)
        {
            isDead = true;
        }
        else if (curHealth >= 1 && isDead)
        {
            isDead = false;
        }

        if (m_hurt == true)
        {
            StartCoroutine(WaitTime());
            m_hurt = false;
        }
    }

    private void FixedUpdate()
    {
        m_Grounded = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
                m_Grounded = true;
        }
        m_Anim.SetBool("Ground", m_Grounded);

        // Set the vertical animation
        m_Anim.SetFloat("vSpeed", m_Rigidbody2D.velocity.y);

		// Set animation for death
		m_Anim.SetBool("isDead", isDead);       

        // Set animation for hurt
        m_Anim.SetBool("Hurt", m_hurt);        

        // Set animation for happy
        m_Anim.SetBool("Happy", m_happy);
        
    }
    public void RpcMove(float move, bool jump, bool m_crouch, bool m_aim, bool m_melee, bool m_shoot, bool m_throw)
    {
        // If crouching, check to see if the character can stand up
        if (!m_crouch && m_Anim.GetBool("Crouch"))
        {
            if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
            {
                m_crouch = true;
            }
        }

        // Set animation for shoot
        m_Anim.SetBool("Shoot", m_shoot);

        // Set animation for aim
        m_Anim.SetBool("Aim", m_aim);

        // Set animation for crouch
        m_Anim.SetBool("Crouch", m_crouch);

        // Set animation for melee
        m_Anim.SetBool("Melee", m_melee);

        // Set animation for throw
        m_Anim.SetBool("Throw", m_throw);

        //only control the player if grounded or airControl is turned on
        if (m_Grounded || m_AirControl)
        {
            // The Speed animator parameter is set to the absolute value of the horizontal input.
            m_Anim.SetFloat("Speed", Mathf.Abs(move));

            // Move the character
            m_Rigidbody2D.velocity = new Vector2(move * m_MaxSpeed, m_Rigidbody2D.velocity.y);

            // If the input is moving the player right and the player is facing left...
            if (move > 0 && !m_FacingRight)
            {
                // ... flip the player.
				RpcFlip();
            }
            // Otherwise if the input is moving the player left and the player is facing right...
            else if (move < 0 && m_FacingRight)
            {
                // ... flip the player.
                RpcFlip();
            }
        }
        // If the player should jump...
        if (m_Grounded && jump && m_Anim.GetBool("Ground"))
        {
            // Add a vertical force to the player.
            m_Grounded = false;
            m_Anim.SetBool("Ground", false);
            m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
        }
    }

	[ClientRpc]
	private void RpcFlip()
	{
		m_FacingRight = !m_FacingRight;
			//GetComponent<SpriteRenderer> ().flipX = false;
			transform.Rotate (0, 180, 0);
			//theScale.y = 180;
			//transform.localScale = theScale;
	}

    public void TakeDamage(int amount)
    {
		if (!isServer) 
		{
			return;
		}
        curHealth -= amount;
        m_hurt = true;
        m_Anim.SetBool("Hurt", true);
        
    }

    float CalculateHealth()
    {

        return curHealth / maxHealth;
    }

    void Death()
    {
		if (isDead == true) 
		{
			if (Input.GetKey (KeyCode.P)) 
			{
				SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
			}
		}
        

        //Load last check point

    }

    public void Attack()
    {

    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(1);
    }
}
