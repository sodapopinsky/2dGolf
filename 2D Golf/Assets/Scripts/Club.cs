using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Club {


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
	// {Strength
	public static Dictionary <clubType, float[]> clubAttributes = new Dictionary<clubType,float[]>{
		{clubType.Driver, new float[]{100, 50}}  // {Velocityx, VelocityY}
	};



	public float velocityX;

	public Club(clubType clubtype){

		float[] attr;
		if (clubAttributes.TryGetValue (clubtype, out attr)) 
		{
			this.velocityX = attr[0];
		} 
		else {
			Debug.Log("Club Attributes not set"); // should throw exception
			this.velocityX = 5;
				} 
	
		}

}
