using UnityEngine;
using System.Collections;

public class RemoveObject : MonoBehaviour {

	public float limit = 3;

	private float time = 0F;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (time > limit) {
			GameObject.Destroy(gameObject);
		}
	}
}
