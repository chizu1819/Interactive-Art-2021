using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class  moving : MonoBehaviour {

	public SerialHandler serialHandler;

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
			string[] angles = message.Split(',');
			//text.text = "x:" + angles[0] + "\n" + "y:" + angles[1] + "\n" + "z:" + angles[2] + "\n" + "touch or leaving:" + angles[3] + "\n"; // シリアルの値をテキストに表示
			transform.Translate((float.Parse(angles[2]))/1000, 0f, 0f);

			if(angles[3] == "touching")
			{
				Debug.Log("touch!");
				Vector3 angle = new Vector3(0, 20, 0);
				transform.rotation = Quaternion.Euler(angle);
			}

		} 
		catch (System.Exception e) {
			Debug.LogWarning(e.Message);
			
		}
	}
}