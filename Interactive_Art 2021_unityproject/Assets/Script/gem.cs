using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gem : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Player") {
			Debug.Log("Gem");
			collision.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
			Destroy(gameObject, 0.2f);
		}
	}
}
