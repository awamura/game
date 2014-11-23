using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
	public float SPEED = 1F;
	public float ROTATE_SPEED = 2F;
	public float GRAVITY = 200F;

	Animator animator;
	CharacterController character;

	private float beforePositionZ;
	private float speedX;
	private bool isRotateMode;
	private float beforeRotate;

	Vector3 velocity;

	//private bool isGround = false;

	// Use this for initialization
	void Start () {
		beforePositionZ =  transform.position.z;
		speedX = SPEED;
		
		animator = GetComponent<Animator>();
		character = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Mathf.Abs (speedX) > 0.001) {
			velocity = new Vector3(speedX, 0, 0);
			animator.SetFloat("Speed", Mathf.Abs (speedX));
		}

		velocity.y -= GRAVITY * Time.deltaTime;
		CollisionFlags flag = character.Move(velocity * Time.deltaTime);
		
		if (isRotateMode) {
			if (Mathf.Abs (beforeRotate - transform.rotation.y) < (1 - ROTATE_SPEED / 180)) {
				Vector3 angle = new Vector3 (0, ROTATE_SPEED, 0);
				transform.Rotate (angle);
			} else {
				transform.rotation = new Quaternion(0, Mathf.Round(transform.rotation.y), 0, 0);
				print (transform.rotation.y);
				isRotateMode = false;
				speedX = -SPEED * (transform.rotation.y * 2 - 1);
			}
		} else {
			if ((flag & CollisionFlags.Sides) == CollisionFlags.Sides) {
				startRorate();
			}
		}
		
		beforePositionZ = transform.position.z;
	}

	private void startRorate() {
		isRotateMode = true;

		beforeRotate = transform.rotation.y;
		speedX = 0;
		animator.SetFloat("Speed", 0.1F);
	}
}
