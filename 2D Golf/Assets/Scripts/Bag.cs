using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Bag : MonoBehaviour  {



	private GUIManager gui;
	public List<Club> clubs = new List<Club>();
	public int currentClubIndex = 0;
	// Use this for initialization
	void Start(){


		GameObject GUIManagerObject = GameObject.Find ("GUIManager");
		gui = GUIManagerObject.GetComponent("GUIManager") as GUIManager;
		populateDefault ();
		doChangeClub ();

	}
	
	void Update(){
		checkChangeClub();
		}
	void populateDefault(){
		clubs.Add (new Club (Club.clubType.Driver));
		clubs.Add (new Club (Club.clubType.Wood3));
		clubs.Add (new Club (Club.clubType.PitchingWedge));
	
	}


	void checkChangeClub(){
		if (Input.GetKeyDown (KeyCode.DownArrow
		                      )) {
			Debug.Log (clubs.Count);
			if (currentClubIndex < clubs.Count - 1) {
				Debug.Log ("down");
				currentClubIndex++;
				doChangeClub ();
			}
		}
		
		if (Input.GetKeyDown (KeyCode.UpArrow
		                      )) {
			if (currentClubIndex > 0) {
				currentClubIndex--;
				doChangeClub ();
			}
		}
	}
	
	void doChangeClub(){
		gui.currentClubText = clubs[currentClubIndex].clubName;
		gui.expectedYardsText = "Expected Distance: " + clubs[currentClubIndex].expectedYards.ToString () + "Yards";
	}

}
