using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextManagerSc : MonoBehaviour {

	public Text scoretxt;
	public Text livestxt;
	GameObject player;


	// Use this for initialization
	void Start () {

		player = GameObject.FindGameObjectWithTag ("Player");
	
	}
	
	// Update is called once per frame
	void Update () {

		scoretxt.text = "Score: " + player.GetComponent<PlayerSc> ().score;
		livestxt.text = "Lives: " + player.GetComponent<PlayerSc> ().lives;
	
	}
}
