using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	private LevelManager levelManager;

	public Sprite[] hitSprites;
	private int timesHit;

	// Use this for initialization
	void Start () {
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}

	void OnCollisionEnter2D (Collision2D collision) {
		bool isBreakable = (this.tag == "Breakable");
		print (this.tag);
		if (isBreakable) {
			HandleHits();
		}
	}
	
	void HandleHits () {
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits){
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
	
	// TODO Remove this method once we can actually win!
	void SimulateWin() {
		levelManager.LoadNextLevel();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
