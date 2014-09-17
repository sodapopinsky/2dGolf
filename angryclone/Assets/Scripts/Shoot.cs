using UnityEngine;
using System.Collections;


public class Shoot : MonoBehaviour {

	public GUIText clubTitle;
	public GUIText yardsToPinText;
	public int currentClubIndex = 0;
	private Vector3 yardsToPin;
	private string view;
	private float yardsTraveled;



	public Club[] clubs = new Club[] { 
		new Club ("Driver", 350.0f, 50.0f, 1.0f, 0.7f,0.0f, 600.0f),
		new Club ("3 Wood", 310.0f, 50.0f, 1.0f, 0.7f,0.0f, 500.0f),
		new Club ("3 Iron", 30.0f, 30.0f, 1.0f, 0.5f,10000.0f,350.0f),
		new Club ("4 Iron", 150.0f, 50.0f, 1.0f, 0.6f,20000.0f,350.0f),
		new Club ("9 Iron", 200.0f, 50.0f, 1.0f, 0.7f,80000.0f,300.0f),
		new Club ("Wedge", 70.0f, 60.0f, 1.0f, 0.7f,10000.0f,100.0f),
		new Club ("Backup", -10.0f, -10.0f, 1.0f, 0.7f,100.0f,-10.0f)
	}; 
	public Club currentClub;

	// 1 - Designer variables
	

	private Vector2 speed = new Vector2(1, 1);
	private Vector2 direction = new Vector2(1, 1);
	private  Vector2 movement;
	public Transform pin;
	public Transform ball;

	public Transform farLeft;
	public Transform farRight;
	public Transform top;
	public Transform bottom;
	public Transform target;

	void Start(){
		// 2 - Movement

		currentClub = clubs[currentClubIndex];
		clubTitle.text = "Club: " + currentClub.title + "transform:  " + currentClub.transformX;
		view = "shot";

		yardsToPin.x = (pin.position.x - ball.position.x) * 2;
		yardsToPinText.text = "Yards to Pin: " + yardsToPin.x;
	}

		
	void Update()
	{

		yardsToPin.x = (pin.position.x - ball.position.x) * 2;
		yardsTraveled = ball.position.x / 2;
		//yardsToPinText.text = "Yards Traveled: " + Mathf.Round(yardsTraveled);

		if (Input.GetKeyDown (KeyCode.DownArrow
		                      )) {
			if (currentClubIndex < clubs.Length - 1) {
				currentClubIndex++;
				changeClub ();
			}
			
		}

		if (view == "plan") {
						if (Input.GetKeyDown (KeyCode.LeftArrow
						)) {
								panLeft ();
		
						}
						if (Input.GetKeyDown (KeyCode.RightArrow
						)) {
								panRight ();
			
						}
				}

		if (Input.GetKeyDown (KeyCode.UpArrow
		                      )) {
			if (currentClubIndex > 0) {
				currentClubIndex--;
				changeClub ();
			}
		}


		if (Input.GetKeyDown (KeyCode.Space
		                      )) {
			Debug.Log ("space");
			speed = new Vector2 (currentClub.speedX, currentClub.speedY);
			direction = new Vector2 (currentClub.directionX, currentClub.directionY);
			movement = new Vector2 (
				speed.x * direction.x,
				speed.y * direction.y);
			// Apply movement to the rigidbody
			rigidbody2D.AddTorque(currentClub.torque);

			rigidbody2D.velocity = movement;

		}



		}

	void changeClub(){



		currentClub = clubs[currentClubIndex];
		clubTitle.text = currentClub.title;
	
		clubTitle.text = "Club: " + currentClub.title + "transform:  " + currentClub.transformX;


		Vector3 newPosition = target.position;
		newPosition.x = ball.localPosition.x + currentClub.transformX;
		yardsToPinText.text = "ball x: " + ball.localPosition.x + "clubtrans: " + currentClub.transformX
			+ "final: " + newPosition.x;
		target.position = newPosition;


		newPosition = Camera.main.transform.position;
	
		newPosition.x = target.position.x;
	
		//newPosition.y = Mathf.Clamp (newPosition.y, bottom.position.y, top.position.y);
		Camera.main.orthographicSize = 20.0f;
		Camera.main.transform.position = newPosition;

	}

	void FixedUpdate()
	{
	
	

	}

	void OnGUI () {
		// Make a background box
		//GUI.Box(new Rect(10,10,100,90), "Loader Menu");
		
		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(20,90,80,20), "Shoot")) {
			shootView();
		}
		
		// Make the second button.
		if(GUI.Button(new Rect(20,120,80,20), "Plan")) {
			planView();
		}
	}

	void panLeft(){

		Vector3 newPosition = Camera.main.transform.position;
		

		
		newPosition.x = Camera.main.transform.position.x - 3;
		newPosition.y = Camera.main.transform.position.y;
		newPosition.x = Mathf.Clamp (newPosition.x, farLeft.position.x, farRight.position.x);

		
		Camera.main.transform.position = newPosition;
	}

	void panRight(){
		Vector3 newPosition = Camera.main.transform.position;
		

		
		newPosition.x = Camera.main.transform.position.x + 3;
		newPosition.y = Camera.main.transform.position.y;
		newPosition.x = Mathf.Clamp (newPosition.x, farLeft.position.x, farRight.position.x);
		
		
		Camera.main.transform.position = newPosition;
	}

		void shootView(){
		Vector3 newPosition = Camera.main.transform.position;
		
		
		Camera.main.orthographicSize = 8.0f;
		
		newPosition.x = ball.position.x;
		newPosition.y = ball.position.y;
		newPosition.x = Mathf.Clamp (newPosition.x, farLeft.position.x, farRight.position.x);
		newPosition.y = -2.5f;
		
		Camera.main.transform.position = newPosition;
	}
	void planView(){
		view = "plan";
		Vector3 newPosition = Camera.main.transform.position;


		Camera.main.orthographicSize = 20.0f;
	

		newPosition.x = Mathf.Clamp (newPosition.x, farLeft.position.x, farRight.position.x);
		newPosition.y = Mathf.Clamp (newPosition.y, bottom.position.y, top.position.y);

		Camera.main.transform.position = newPosition;
	}

}




