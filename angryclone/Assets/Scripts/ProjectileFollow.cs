using UnityEngine;
using System.Collections;

public class ProjectileFollow : MonoBehaviour {

	public Transform projectile;
	public Transform farLeft;
	public Transform farRight;
	public Transform top;
	public Transform bottom;
	private bool wasShooting = false;
	// Update is called once per frame
	void Update () {
		if (isShooting()) {
					
						Vector3 newPosition = transform.position;
						newPosition.x = projectile.position.x;
				
	
						newPosition.x = Mathf.Clamp (newPosition.x, farLeft.position.x, farRight.position.x);
							newPosition.y = Mathf.Clamp (newPosition.y, bottom.position.y, top.position.y);
						newPosition.y = -2.5f;
						transform.position = newPosition;
				}
	}

	private bool isShooting(){

		if (projectile.rigidbody2D.velocity.x > 0.9) {
		
			if(wasShooting == false){
			
						wasShooting = true;
				startShooting();
			}
						return true;
				}
		if (projectile.rigidbody2D.velocity.y > 0.9) {
			if(wasShooting == false){
				wasShooting = true;
				startShooting();
			}
			return true;
				}
		if (wasShooting == true) {
			stopShooting();
						wasShooting = false;
				}
		return false;
		
	}
	private void startShooting(){
		Debug.Log ("herestartshooting");
		Camera.main.orthographicSize = 8.0f;
	}
	private void stopShooting(){
		Camera.main.orthographicSize = 20.0f;
		Vector3 newPosition = Camera.main.transform.position;
		newPosition.y = Mathf.Clamp (newPosition.y, bottom.position.y, top.position.y);
		Camera.main.transform.position = newPosition;
		}



}
