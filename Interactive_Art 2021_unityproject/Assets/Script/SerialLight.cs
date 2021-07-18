using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SerialLight : MonoBehaviour {

	public SerialHandler serialHandler;
	public Text text;
	public GameObject cube;

	// Use this for initialization
	void Start () {
		//信号を受信したときに、そのメッセージの処理を行う
		serialHandler.OnDataReceived += OnDataReceived;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/*
	 * シリアルを受け取った時の処理
	 */
	void OnDataReceived(string message) {
		try 
		{
			//text.text = message; // シリアルの値をテキストに表示
			//Debug.Log("d" + message);

			string[] angles = message.Split(',');
			text.text = "x:" + angles[0] + "\n" + "y:" + angles[1] + "\n" + "Pressure:" + angles[2] + "\n" + angles[3] + "\n"; // シリアルの値をテキストに表示

			Vector3 angle = new Vector3(float.Parse(angles[0]), float.Parse(angles[1]), float.Parse(angles[2]));
			cube.transform.rotation = Quaternion.Euler(angle);

			if(angles[3] == "touching")
			{
				Debug.Log("touch!");
			}
		} 
		catch (System.Exception e) {
			Debug.LogWarning(e.Message);
			
		}
	}
}