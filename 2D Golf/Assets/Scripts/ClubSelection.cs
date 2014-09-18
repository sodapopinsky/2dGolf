using UnityEngine;
using System.Collections;

public class ClubSelection : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		//Gets next higest club
		if (Input.GetKeyDown (KeyCode.DownArrow
		                      )) {
			changeClub ();
			/*
			if (CameraScript.myBag.currentClubIndex < CameraScript.myBag.clubs.Length - 1) {
				CameraScript.myBag.currentClubIndex++;
				changeClub ();
				*/
			}
			
		}


	void changeClub(){
	

	}


}
