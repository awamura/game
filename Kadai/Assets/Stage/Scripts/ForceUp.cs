﻿using UnityEngine;
using System.Collections;

public class ForceUp : MonoBehaviour {

	public float power;

	void Update() {
		RaycastHit hit;
		if (Physics.Raycast(transform.position, Vector3.up, out hit, 1)) {
			Character script = GameObject.Find("BigHeads").GetComponent<Character>();
			script.Jump();
			Debug.Log ("Jump");
		}
	}
}
