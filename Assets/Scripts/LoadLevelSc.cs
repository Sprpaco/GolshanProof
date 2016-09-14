using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadLevelSc : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void pickDifficulty(int diff){

		PlayerPrefs.SetInt ("difficulty", diff);
		changeScene (1);

	}

	public void changeScene(int scene){

		SceneManager.LoadScene (scene);

	}

	public void quitApplication(){

		Application.Quit ();

	}
}
