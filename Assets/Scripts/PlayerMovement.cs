using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D characterController;
	public Animator playerAnimator;
	public float runSpeed = 40f;

	float horizontalMovement = 0f;
	bool jump = false;
	bool crouch = false;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
        // Press W key to jump
        if (Input.GetKeyDown("w"))
        {
            jump = true;
        }

        // Press and holf S key to crouch
        if (Input.GetKeyDown("s"))
        {
            crouch = true;
        }
        else if (Input.GetKeyUp("s"))
        {
            crouch = false;
        }

        // Set the horizontal movement speed
        horizontalMovement = Input.GetAxisRaw ("Horizontal") * runSpeed;
		playerAnimator.SetFloat ("Speed", Mathf.Abs(horizontalMovement));
        playerAnimator.SetBool ("isJump", !characterController.m_Grounded);
        playerAnimator.SetBool ("isCrouch", characterController.m_wasCrouching);
	}

	void FixedUpdate () {
		// Call the Move function in CharacterController2D class
		characterController.Move (horizontalMovement * Time.fixedDeltaTime, crouch, jump);
		jump = false; // Disable jump after the player jumps
	}
}
