using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
	public float SPEED = 0.1F;
	public float ROTATE_SPEED = 1F;

	private float beforePositionZ;
	private float v;
	private bool isRotateMode;
	private float afterRotate;

	//private bool isGround = false;

	// Use this for initialization
	void Start () {
		beforePositionZ =  transform.position.z;
		v = SPEED;

		
		afterRotate = transform.rotation.y + 1;
	}
	
	// Update is called once per frame
	void Update () {
//		print (Mathf.Abs(afterRotate - transform.rotation.y));
//		if (Mathf.Abs (afterRotate - transform.rotation.y) > 0.01) {
//			Vector3 angle = new Vector3 (0, ROTATE_SPEED, 0);
//			transform.Rotate (angle);
//		} else {
//			Vector3 angle = new Vector3 (transform.rotation.x, transform.rotation.y + 1, transform.rotation.z);
//		}

//		isGround = true;
//		if (isGround) {
//			print ("false");
//			isGround = false;
//		} else {
//			speed *= -1;
//		}
		
		transform.Translate (0, 0, v);

//		if (Mathf.Abs (v) > 0.001) {
//			transform.Translate (0, 0, v);
//		}

		if (isRotateMode) {
			if (Mathf.Abs (afterRotate - transform.rotation.z) > ROTATE_SPEED) {
//				Vector3 angle = new Vector3(0, ROTATE_SPEED, 0);
//				transform.Rotate(angle);
				transform.rotation.Set(0,0, afterRotate,0);
			} else {
				transform.rotation.Set(0,0, afterRotate,0);
				isRotateMode = false;
				v = SPEED;
			}
		}

		if (!isRotateMode && Mathf.Abs (beforePositionZ - transform.position.z) < SPEED * 0.5) {
			startRorate();
		}
		
		beforePositionZ = transform.position.z;
	}

	private void startRorate() {
		//isRotateMode = true;

		//print (transform.rotation.z);
		afterRotate = transform.rotation.y + 1;
		//v = 0;
	}

//	void OnCollisionStay(Collision collisionInfo) {
//		if (collisionInfo.gameObject.tag == "ground") {
//			print("true");
//			isGround = true;
//		}
//	}
}
