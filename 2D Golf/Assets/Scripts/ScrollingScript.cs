using UnityEngine;
using System.Collections;

public class ScrollingScript : MonoBehaviour {



	public Transform background;
	public Transform ball;

	private Vector2 speed = new Vector2(2, 2);
	private Vector2 direction = new Vector2(1, 0);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		// Movement
		/*
		Vector3 movement = new Vector3(
			speed.x * direction.x,
			speed.y * direction.y,
			0);
		
		movement *= Time.deltaTime;
		Camera.main.transform.Translate(movement);
		background.transform.Translate(movement);

*/
	}
}
