using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverSc : MonoBehaviour {

	public Text reasonLost;

	void Start(){

		if(PlayerPrefs.GetString("Reason") == null)
			reasonLost.text = "You jumped to this screen without playing";
		if (PlayerPrefs.GetString ("Reason") == "Lives")
			reasonLost.text = "You lost all your lives";
		if (PlayerPrefs.GetString ("Reason") == "Score")
			reasonLost.text = "You didn't get a high enough score. Maybe try a lower difficulty?";
	}

}
