using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseColider : MonoBehaviour {

	private LevelManager levelManager;

	void OnTriggerEnter2D (Collider2D trigger)
	{
		print("Trigger");
		levelManager.LoadLevel("Lose");
	}
	 	
	void Start ()
	{
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
}