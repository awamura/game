using UnityEngine;
using System.Collections;

public class ForceUp : MonoBehaviour {

	public float power;

	void OnCollisionEnter(Collision collision) {
		GameObject targetObject = collision.gameObject;
		targetObject.rigidbody.AddForce (Vector3.up.normalized * power, ForceMode.VelocityChange);
		Debug.Log ("add force");
	}
}
