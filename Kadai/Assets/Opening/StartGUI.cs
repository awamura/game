using UnityEngine;
using System.Collections;

public class StartGUI: MonoBehaviour {
	
	void OnGUI() {
		if (GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height / 2 + 50, 100, 50), "Start")) {
			// クリックされたらStage01シーンをロードする
			Application.LoadLevel ("Main");
		}
	}
}