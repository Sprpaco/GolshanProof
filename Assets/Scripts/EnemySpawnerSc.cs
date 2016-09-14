using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EnemySpawnerSc : MonoBehaviour {

	[System.Serializable]
	public class WaveComponent{

		public GameObject enemyPrefab;
		public int num;
		[System.NonSerialized]
		public int spawned = 0;

	}

	//This is the array of all the waves
	public WaveComponent[] waveComps;
	Camera mainCam;
	float spawnCD = 1.5f;
	float spawnCDleft;

	float waveCD = 0.05f;
	float waveCDleft;
	GameObject player;

	// Use this for initialization
	void Start () {

		mainCam = Camera.main;
		spawnCDleft = spawnCD;
		waveCDleft = waveCD;
		player = GameObject.FindGameObjectWithTag ("Player");

	}
	
	// Update is called once per frame
	void Update () {

		spawnCDleft -= Time.deltaTime;
		if (spawnCDleft < 0) {

			spawnCDleft = spawnCD;
			bool didSpawn = false;

			foreach (WaveComponent wc in waveComps) {
				if (wc.spawned < wc.num) {
					Vector3 randomPos = new Vector3(Random.Range (0, Screen.width),Screen.height,0);
					randomPos = mainCam.ScreenToWorldPoint (randomPos);
					randomPos.y += 1;
					randomPos.z = 0;
					Instantiate (wc.enemyPrefab, randomPos, Quaternion.identity);
					didSpawn = true;
					wc.spawned++;
					break;
				}
			}

			if (didSpawn == false) {
					
				if (transform.parent.childCount > 1) {
					if (waveCDleft >= 0)
						waveCDleft -= Time.deltaTime;
					else {
						transform.parent.GetChild (1).gameObject.SetActive (true); 
						waveCDleft = waveCD;
						player.GetComponent<PlayerSc> ().fireCD -= 0.1f;
						Destroy (gameObject);
					}
				} else {
					if (GameObject.FindGameObjectsWithTag ("enemy").Length == 0) {
						if (player.GetComponent<PlayerSc> ().score >= player.GetComponent<PlayerSc> ().minScore) {
							SceneManager.LoadScene (3);
						} else {
							PlayerPrefs.SetString ("Reason", "Score");
							SceneManager.LoadScene (2);
						}
					}	
				}
			}
		}
	}
}
