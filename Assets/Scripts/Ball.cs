using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public AudioClip clip;
	private Paddle paddle; 
	private Vector3 paddleTOBallVector;
	private bool hasStarted = false ;
	private Rigidbody2D rigi;


	// Use this for initialization
	private void Awake()
 {
     rigi = GetComponent<Rigidbody2D>();
 }
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleTOBallVector = this.transform.position - paddle.transform.position ;
	}
	
	// Update is called once per frame
	void Update ()
	{ 
		if(!hasStarted){
			this.transform.position = paddle.transform.position + paddleTOBallVector;

			if (Input.GetMouseButtonDown(0)) {
			hasStarted = true ; 
			rigi.velocity = new Vector2 (2f, 10f);
			} 
		}
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		Vector2 tweak = new Vector2 (Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));

		if (hasStarted) {
			AudioSource.PlayClipAtPoint (clip, transform.position);
			rigi.velocity += tweak ;
		}
	}
}
