using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer MusicPlayerinstance = null;
	
	// Use this for initialization
	void Awake ()
	{
		if (MusicPlayerinstance != null) {
			Destroy (gameObject);
			print ("Duplicate music player destroyed");
		} else {
			MusicPlayerinstance = this;
			GameObject.DontDestroyOnLoad(gameObject);

		}
	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
