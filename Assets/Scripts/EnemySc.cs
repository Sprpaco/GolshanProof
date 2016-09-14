using UnityEngine;
using System.Collections;

public class EnemySc : MonoBehaviour {

	GameObject player;
	public float dropSpeed;
	public int health;
	public int worth;

	// Use this for initialization
	void Start () {

		player = GameObject.FindGameObjectWithTag ("Player");
	
	}
	
	// Update is called once per frame
	void Update () {

		//Move the enemy down or lose a life
		if (transform.position.y <= -6) {
			player.GetComponent<PlayerSc> ().LoseLife ();
			Destroy (gameObject);
		}else
			transform.Translate(Vector3.down * Time.deltaTime * dropSpeed);
	
	}

	public void TakeDamage(){

		health--;
		if (health <= 0)
			Die ();

	}

	public void Die(){
		
		player.GetComponent<PlayerSc> ().Score (worth);
		Destroy (gameObject);

	}
}
