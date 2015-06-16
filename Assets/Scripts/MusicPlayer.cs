﻿using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	void Awake () {
		Debug.Log ("Music Player Awake " + GetInstanceID());
		if (instance != null) {
			Destroy (gameObject);
			print ("Duplicate music player self-destructing!");
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}		
	}

	static MusicPlayer instance = null;

	// Use this for initialization
	void Start () {
		Debug.Log ("Music Player Start " + GetInstanceID());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
