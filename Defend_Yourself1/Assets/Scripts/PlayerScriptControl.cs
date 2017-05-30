using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(PlayerScript))]
public class PlayerScriptControl : MonoBehaviour
{
    private PlayerScript m_Character;
    private bool m_Jump;
    private bool m_shoot;

    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    private void Awake()
    {
        m_Character = GetComponent<PlayerScript>();
    }


    private void Update()
    {
        if (!m_Jump)
        {
            // Read the jump input in Update so button presses aren't missed.
            m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        }

    }


    private void FixedUpdate()
    {
        // Read the inputs.
        bool m_crouch = Input.GetKey(KeyCode.LeftControl);
        bool m_aim = Input.GetKey(KeyCode.F);
        bool m_melee = Input.GetKey(KeyCode.G);
        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        bool m_shoot = Input.GetKey(KeyCode.C);
        // Pass all parameters to the character control script.
        m_Character.Move(h, m_Jump, m_crouch, m_aim, m_melee, m_shoot);
        m_Jump = false;
    }


}

