using UnityEngine;
using System.Collections;

public class SpawnCube : MonoBehaviour {

	/** generating cube object */
	public GameObject cubeM;
	/** generating large cube object */
	public GameObject cubeL;
	/** spawn mode */
	public int spawnMode = 1;

	public GUIText spawnModeView;

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

		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			spawnMode = 1;
		} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			spawnMode = 2;	
		}

		spawnModeView.text = "SpawnMode:" + spawnMode;
	}

	IEnumerator CreateCube(Vector3 clickPos) {

		Vector3 vec = Camera.main.ScreenToWorldPoint (clickPos);
		vec.x = Mathf.Round(vec.x);
		vec.y = Mathf.Round(vec.y);

		GameObject targetCube;
		if (spawnMode == 1) {
			Ray ray = Camera.main.ScreenPointToRay(clickPos);
			if (!Physics.Raycast(ray)) {
				targetCube = cubeM;
				Instantiate (targetCube, vec, targetCube.transform.rotation);
				yield return null;
			}
		} else {
			Ray firstStepRay = Camera.main.ScreenPointToRay(clickPos);
			Ray secondStepRay = Camera.main.ScreenPointToRay(new Vector3(clickPos.x, clickPos.y + 50, clickPos.z));
			if (!Physics.Raycast(firstStepRay) && !Physics.Raycast(secondStepRay)) {
				targetCube = cubeL;
				Instantiate (targetCube, vec, targetCube.transform.rotation);
			}
		}
		yield return null;
	}
}
