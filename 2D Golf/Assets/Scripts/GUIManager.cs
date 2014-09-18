using UnityEngine;
using System.Collections;

public  class GUIManager : MonoBehaviour {
	
	public string expectedYardsText;
	public string currentClubText;

	void OnGUI() {
		GUI.Label(new Rect (5, 15, 300, 20), currentClubText);
		GUI.Label(new Rect (5, 35, 300, 20), expectedYardsText);
	}


}
