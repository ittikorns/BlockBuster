using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	private LevelManager levelManager;

	public AudioClip crack;
	public Sprite[] hitSprites;
	private int timesHit;
	public GameObject smoke;

	public static int breakableCount = 0;
	private bool isBreakable;

	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		// Keep track of breakable bricks
		if (isBreakable) {
			breakableCount++;
			print (breakableCount);
		}
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}

	void OnCollisionEnter2D (Collision2D collision) {
		AudioSource.PlayClipAtPoint (crack, transform.position);
		if (isBreakable) {
			HandleHits();
		}
	}
	
	void HandleHits () {
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits){
			breakableCount--;
			levelManager.BrickDestroyed();
			GameObject smokePuff = Instantiate (smoke, transform.position, Quaternion.identity) as GameObject;
			smokePuff.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer>().color;
			print (breakableCount);
			Destroy(gameObject);
		} else {
			LoadSprites();
		}	
	}
	
	void LoadSprites() {
		int spriteIndex = timesHit - 1;
		if (hitSprites[spriteIndex]) {
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
	}

	// Update is called once per frame
	void Update () {
		
	}

	// TODO Remove this method once we can actually win!
	void SimulateWin() {
		levelManager.LoadNextLevel();
	}

}
