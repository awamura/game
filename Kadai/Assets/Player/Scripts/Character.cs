using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
	public float SPEED = 3F;
	public float ROTATE_SPEED = 2F;
	public float GRAVITY = 0.1F;
	public float JUMP_POWER = 50F;
	public float CHIMNEY_SPEED = 5F;
	public float ENEMY_POWER = 30F;

	Animator animator;
	CharacterController character;
	GameObject gameController;

	private float speedX;
	private bool isRotateMode;
	private float beforeRotate;
	private float beforePositionY;
	private bool goal;

	Vector3 velocity;

	//private bool isGround = false;

	// Use this for initialization
	void Start () {
		speedX = SPEED;
		
		animator = GetComponent<Animator>();
		character = GetComponent<CharacterController>();
		gameController = GameObject.Find ("GameController");

		goal = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (goal) {
			if (beforePositionY - 3F < transform.position.y) {
				transform.Translate(0, -CHIMNEY_SPEED * Time.deltaTime, 0);
			}
			return;
		}
		if (Mathf.Abs (speedX) > 0.001) {
			velocity.z = speedX;
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
				StartRorate();
			}
		}
	}

	private void StartRorate() {
		isRotateMode = true;

		beforeRotate = transform.rotation.y;
		speedX = 0;
		animator.SetFloat("Speed", 0.1F);
	}

	void OnControllerColliderHit(ControllerColliderHit hit){
		if (hit.gameObject.tag == "chimney") {
			float distance = Mathf.Abs(hit.gameObject.transform.position.z - 3.3f - transform.position.z);
			if (distance < 0.01) {
				Goal();
			}
		}
		if (hit.gameObject.tag == "enemy") {
			gameController.SendMessage("GameOver");
			velocity.y = ENEMY_POWER;
		}
	}

	public void Jump(){
		velocity.y = JUMP_POWER;
	}
	
	public void Goal(){
		speedX = 0;
		velocity.z = 0;
		animator.SetFloat("Speed", 0.0F);
		beforePositionY = transform.position.y;
		gameController.SendMessage("GameClear");
		goal = true;
	}
}
