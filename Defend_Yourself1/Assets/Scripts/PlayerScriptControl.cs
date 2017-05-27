﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(PlayerScript))]
public class PlayerScriptControl : MonoBehaviour
{
    private PlayerScript m_Character;
    private bool m_Jump;



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

    }


    private void FixedUpdate()
    {
        // Read the inputs.
        bool m_crouch = Input.GetKey(KeyCode.LeftControl);
        bool m_aim = Input.GetKey(KeyCode.F);
        bool m_melee = Input.GetKey(KeyCode.G);
        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        // Pass all parameters to the character control script.
        m_Character.Move(h, m_Jump, m_crouch, m_aim, m_melee);
        m_Jump = false;
    }


}

