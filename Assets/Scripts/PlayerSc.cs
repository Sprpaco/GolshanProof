using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerSc : MonoBehaviour {

	float moveSpeed;
	public GameObject bulletprefab;
	public GameObject APIprefab;
	Camera mainCam;
	public int score;
	public int minScore;
	public int lives;

	public float fireCD = 1.5f;
	float fireCDleft;
	bool canShoot;

	public AudioClip CAudio, VAudio, APIAudio;
	int audioIndex;

	// Use this for initialization
	void Start () {

		mainCam = Camera.main;
		lives = 20;
		score = 0;
		canShoot = true;

		if (Screen.width >= 1000)
			moveSpeed = 15f;
		if (Screen.width < 1000)
			moveSpeed = 10f;
		audioIndex = 0;
		minScore = PlayerPrefs.GetInt ("difficulty");

	}
	
	// Update is called once per frame
	void Update () {

		//If the player runs outs of lives, stop the game.
		if (lives <= 0) {
			PlayerPrefs.SetString ("Reason", "Lives");
			GameOver ();
		}
		//Grab the horizontal input and store the value in a variable.
		float dir = Input.GetAxis ("Horizontal");
		float myPos = mainCam.WorldToScreenPoint (this.transform.position).x;

		//Move toward the horizontal input with a speed over time.
		if (myPos <= Screen.width-15 && myPos >=15)
			transform.Translate (new Vector3 (dir * Time.deltaTime * moveSpeed, 0, 0));
		else if (myPos > Screen.width-15)
			transform.Translate (new Vector3 (-1 * Time.deltaTime * moveSpeed, 0, 0));
		else if(myPos < 15)
			transform.Translate (new Vector3 (1 * Time.deltaTime * moveSpeed, 0, 0));

		//Wait out the fire cooldown, then reset the ability to fire and the cooldown.
		if (canShoot == false) {
			//You just shot
			fireCDleft -= Time.deltaTime;
			if (fireCDleft <= 0) {
				//You CD is done
				canShoot = true;
				fireCDleft = fireCD;
			}
		}

		if (Input.GetButtonDown ("Shoot") && canShoot) {
			Shoot ();
		}
			
	}

	public void Score(int s){

		score += s;

	}

	void GameOver(){

		SceneManager.LoadScene (2);

	}

	public void LoseLife(){

		lives--;

	}

	public void Shoot(){

		Instantiate (bulletprefab, new Vector3 (transform.position.x, -2.5f, transform.position.z), this.gameObject.transform.rotation);
		if (Random.Range (0, 10) == 3 && GetComponent<AudioSource>().isPlaying == false) {
			if (audioIndex == 0) {
				GetComponent<AudioSource> ().PlayOneShot (CAudio);
				audioIndex++;
			} else {
				GetComponent<AudioSource> ().PlayOneShot (VAudio);
				audioIndex--;
			}
		}
		canShoot = false;

	}

	public void FinalShot(){

		Instantiate (APIprefab, new Vector3 (0, -2.5f, 0), this.gameObject.transform.rotation);
		GetComponent<AudioSource> ().PlayOneShot (APIAudio);

	}
}
