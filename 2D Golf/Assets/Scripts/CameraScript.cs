using UnityEngine;
using System.Collections;



public class CameraScript : MonoBehaviour {

	private enum View
	{
		Shot,
		Plan
	}

	public Transform sky;
	public Transform ball;

	public float mainOrthographicSize = 20.0f;
	public float cameraX = 23.1f;
	public float cameraY = 18.5f;
	public float test = 23.1f;
	private static View currentView = View.Plan;


	// Use this for initialization
	void Start () {
		Vector3 newPos = Camera.main.transform.position;
		newPos.x = cameraX;
		newPos.y = cameraY;
		Camera.main.transform.position = newPos;
		Camera.main.orthographicSize = mainOrthographicSize;
		resizeBG ();

		new Bag ();
	}
	
	// Update is called once per frame
	void Update () {
	
	
	}

	void OnGUI() {

		if (GUI.Button (new Rect (10, 0, 150, 50), "Shot"))
				goShotView ();
	if (GUI.Button (new Rect (10, 60, 150, 50), "Plan"))
				goPlanView ();
		
	}

	private void goShotView(){

		Camera.main.orthographicSize = 6.0f;
		Vector3 newPos = Camera.main.transform.position;
		newPos.x = 0.5f;
		newPos.y = 5;
		Camera.main.transform.position = newPos;
		resizeBG ();
		currentView = View.Shot;
		}

	private void goPlanView(){

		Vector3 newPos = Camera.main.transform.position;
		newPos.x = cameraX;
		newPos.y = cameraY;
		Camera.main.transform.position = newPos;
		Camera.main.orthographicSize = mainOrthographicSize;
		resizeBG ();
		currentView = View.Plan;
		}

	void resizeBG(){
		SpriteRenderer sr =
			sky.GetComponent<SpriteRenderer>();
		
		float worldScreenHeight = Camera.main.orthographicSize * 2;
		float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;
		sky.transform.localScale = new Vector3(
			worldScreenWidth / sr.sprite.bounds.size.x,
			worldScreenHeight / sr.sprite.bounds.size.y, 1);

		Vector3 newPos = Camera.main.transform.position;
		newPos.z = 3;
		sky.transform.position = newPos;
		}




}
