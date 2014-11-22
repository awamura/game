using UnityEngine;
using System.Collections;

public class SpawnCube : MonoBehaviour {
	
	public GameObject cube;
	public GameObject cubeL;

	private Vector3 clickPosition;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			clickPosition = Input.mousePosition;
			clickPosition.z = 10f;
			StartCoroutine("CreateCube", clickPosition);
		}
	}


	IEnumerator CreateCube(Vector3 clickPos) {

		Vector3 vec = Camera.main.ScreenToWorldPoint (clickPos);
		vec.x = Mathf.Round(vec.x);
		vec.y = Mathf.Round(vec.y);

		Instantiate (cube, vec, cube.transform.rotation);
		yield return null;
	}

	
}
