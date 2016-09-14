using UnityEngine;
using System.Collections;

public class BulletSc : MonoBehaviour {

	public float moveSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position.y <= 8)
			transform.Translate (Vector3.up * moveSpeed * Time.deltaTime);
		else
			Destroy (gameObject);
	}

	void OnTriggerEnter(Collider col){

		if (col.tag == "enemy") {
			col.GetComponent<EnemySc> ().TakeDamage ();
			Destroy (gameObject);
		}

	}
}
