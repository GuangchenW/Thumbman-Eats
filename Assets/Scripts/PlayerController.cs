using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;
	public float jumpSpeed;

	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate () {
		float xDirection = Input.GetAxis ("Horizontal");
		rb.AddForce (new Vector2 (xDirection, 0) * speed);

		if (Input.GetKeyDown ("space")) {
			rb.AddForce (Vector2.up * jumpSpeed, ForceMode2D.Impulse);
		}
	}
}
