﻿using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name){
		Debug.Log ("Level load requested for: "+name);
		Application.LoadLevel(name);
	}
	
	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit();
	}
	
	public void LoadNextLevel(){
		Debug.Log ("Load next level");
		Application.LoadLevel(Application.loadedLevel + 1);
	}

	public void BrickDestroyed(){
		if (Brick.breakableCount <= 0) {
		    LoadNextLevel();
		}
	}

}
