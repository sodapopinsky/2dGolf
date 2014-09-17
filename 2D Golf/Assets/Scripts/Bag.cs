using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Bag  {



	private List<Club> clubs = new List<Club>();
	private int currentClub;
	// Use this for initialization
	public Bag(){

		populateDefault ();

	}
	


	void populateDefault(){
		clubs.Add (new Club (Club.clubType.Driver));
	
	}
}
