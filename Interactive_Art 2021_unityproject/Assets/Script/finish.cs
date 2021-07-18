using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finish : MonoBehaviour {
	public GameObject goal;
	public GameObject title;

	// Use this for initialization
	void Start () {
		Invoke("DelayMethod",3.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	 void DelayMethod()
    {
        title.gameObject.SetActive(false);
    }

	void OnCollisionEnter(Collision collision) {
    if (collision.gameObject.tag == "Player") {
		Debug.Log("Finish!");
        collision.gameObject.GetComponent<Renderer>().material.color = Color.red;
		Destroy(gameObject, 0.2f);

		goal.gameObject.SetActive(true);//goal表示
    }
}
}
