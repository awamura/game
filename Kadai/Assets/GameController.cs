﻿using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public GUITexture texClear;
	public GUITexture texFaild;
	
	private bool isStageEnd;

	// Use this for initialization
	void Start () {
		texClear.enabled = false;
		texFaild.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GameClear() {
		if (!isStageEnd) {
			texClear.enabled = true;
			isStageEnd = true;
		}
	}

	public void GameOver() {
		if (!isStageEnd) {
			print ("bbbb");
			texFaild.enabled = true;
			isStageEnd = true;
		}
	}
}
