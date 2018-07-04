using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {
	public Sprite[] hitSprites ; 
	public AudioClip crack;
	public GameObject smoke;
	public static int breakableCount = 0;

	private int timesHit; 
	private LevelManager levelManager ; 
	private bool isBreakable;
	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breackable");
		//Keep track of breakabke bricks
		if(isBreakable){
			breakableCount++;
		}
		timesHit = 0 ; 
		levelManager = GameObject.FindObjectOfType<LevelManager>(); 
	}
	// Update is called once per frame
	void Update () {

	}
	void OnCollisionEnter2D (Collision2D collision)
	{
		AudioSource.PlayClipAtPoint (crack, transform.position);
		if (isBreakable) {
			HandleHits ();
		}
	}

	void HandleHits ()
	{
		timesHit++;
		int maxHits = hitSprites.Length +1;
		if (timesHit >= maxHits) {
			breakableCount--;
			levelManager.BrickDestroyed();
			GameObject smokePuff = Instantiate(smoke, gameObject.transform.position , Quaternion.identity) as GameObject;
			Color clr = gameObject.GetComponent<SpriteRenderer>().color;
			smokePuff.GetComponent<ParticleSystem>().startColor = clr;
			Destroy (gameObject);
		} else {
			LoadSprites();
		}
	}

	void LoadSprites ()
	{
		int spriteIndex = timesHit - 1;
		if (hitSprites [spriteIndex] != null) {
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites [spriteIndex];
		} else {
		Debug.LogError("Brick Sprite Missing");
		}
	}

	// TODO destroy later

	void SimulateWin ()
	{
		levelManager.LoadNextLevel();
	}
}
