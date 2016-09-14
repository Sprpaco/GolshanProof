using UnityEngine;
using System.Collections;

public class BackgroundSc : MonoBehaviour {

	public Material bigger;
	public Material smaller;

	// Use this for initialization
	void Start () {

		if(Screen.width < 1000)
			GetComponent<Renderer> ().material = smaller;
		if (Screen.width >= 1000) {
			GetComponent<Renderer> ().material = bigger;
			transform.localScale += new Vector3 (1f, 0, 0);
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
