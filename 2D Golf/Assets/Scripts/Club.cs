using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Club {

	//Define All Clubs
	public enum clubType{
		Driver,
		Wood3,
		Iron3,
		Iron4,
		Iron5,
		Iron6,
		Iron7,
		Iron8,
		Iron9,
		PitchingWedge
	}

	//Set Club Attributes
	public static Dictionary <clubType, object[]> clubAttributes = new Dictionary<clubType,object[]>{
		{clubType.Driver, new object[]{"Driver", 100, 280}},
		{clubType.Wood3, new object[]{"3 Wood", 90,250}},// {Velocityx, Expected Yards}
		{clubType.PitchingWedge, new object[]{"Pitching Wedge",40, 90}}

	};


	public string clubName;
	public float velocityX;
	public float expectedYards;

	public Club(clubType clubtype){

		object[] attr;
		if (clubAttributes.TryGetValue (clubtype, out attr)) 
		{

	
			this.clubName = attr[0].ToString();
			this.velocityX = System.Convert.ToSingle(attr[1]);
			this.expectedYards = System.Convert.ToSingle(attr[2]);
		} 
		else {
			Debug.Log("Club Attributes not set"); // should throw exception
				} 
	
		}

}
