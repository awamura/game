using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public GUITexture texClear;
	public GUITexture texFaild;
	
	private bool isStageEnd;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GameClear() {
		texClear.enabled = true;
		isStageEnd = true;
	}

	public void GameFaild() {
		texFaild.enabled = true;
		isStageEnd = true;
	}
}
