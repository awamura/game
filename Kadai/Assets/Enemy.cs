using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public float ROTATE_SPEED = 10F;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (ROTATE_SPEED * Time.deltaTime, ROTATE_SPEED * Time.deltaTime, ROTATE_SPEED * Time.deltaTime);
	}
}
