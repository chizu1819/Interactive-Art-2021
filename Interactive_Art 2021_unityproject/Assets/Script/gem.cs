using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gem : MonoBehaviour {

	public SerialHandler serialHandler;
	void Start () {
		//信号を受信したときに、そのメッセージの処理を行う
		serialHandler.OnDataReceived += OnDataReceived;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Player") {
			Debug.Log("Gem");
			//collision.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
			Destroy(gameObject, 0.2f);
		}
	}

	/*
	 * シリアルを受け取った時の処理
	 */
	void OnDataReceived(string message) {
		try 
		{
			string[] angles = message.Split(',');

			Vector3 angle = new Vector3(float.Parse(angles[0]), float.Parse(angles[1]), float.Parse(angles[2]));
			transform.rotation = Quaternion.Euler(angle);
		} 
		catch (System.Exception e) {
			Debug.LogWarning(e.Message);
			
		}
	}
}
