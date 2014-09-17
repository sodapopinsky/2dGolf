using UnityEngine;
using System.Collections;

public class Club  {

	public string title;
	public float speedX;
	public float speedY;
	public float directionX;
	public float directionY;
	public float torque;
	public float transformX;
	public Club(string title, float speedX, float speedY, float directionX, float directionY, float torque, float transformX){
		this.title = title;
		this.speedX = speedX;
		this.speedY = speedY;
		this.directionX = directionX;
		this.directionY = directionY;
		this.torque = torque;
		this.transformX = transformX;
	}
}
