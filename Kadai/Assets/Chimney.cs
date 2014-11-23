using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {
	GameObject gameController;
	
	void Start () {
		gameController = GameObject.Find ("GameController");
	}

	void OnCollisionEnter(Collision collisionInfo) {
		if (collisionInfo.gameObject.tag == "character") {
			gameController.SendMessage("GameClear");
		}
	}
}
