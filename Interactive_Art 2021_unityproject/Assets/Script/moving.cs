using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class  moving : MonoBehaviour {

	public SerialHandler serialHandler;
	GameObject scoreObject;
	GameObject rotateObject;
	Rotate script;

	// Use this for initialization
	void Start () {
		//信号を受信したときに、そのメッセージの処理を行う
		serialHandler.OnDataReceived += OnDataReceived;
		scoreObject = GameObject.Find("Count");

		rotateObject = GameObject.Find("Rotate");
		script = rotateObject.GetComponent<Rotate>();
		
	}
	
	void Update () {
		if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0f, 0f, 0.1f);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0f, 0f, -0.1f);
        }
		/*
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-0.1f, 0f, 0f);
        }
		
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(0.1f, 0f, 0f);
        }
		*/
		
	}
	int i=0;
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "gem") {
			Debug.Log("Count!");
			scoreObject.GetComponent<Count>().AddScore();

			serialHandler.Write("1");
            i = 0;
		}
	}

	/*
	 * シリアルを受け取った時の処理
	 */
	void OnDataReceived(string message) {
		try 
		{
			string[] angles = message.Split(',');
			//text.text = "x:" + angles[0] + "\n" + "y:" + angles[1] + "\n" + "z:" + angles[2] + "\n" + "touch or leaving:" + angles[3] + "\n"; // シリアルの値をテキストに表示
			transform.Translate(0f, 0f, (float.Parse(angles[2]))/2000);
			//Debug.Log ("yrotate" + yrotate);
			if(angles[3] == "touching" && Input.GetKey(KeyCode.RightArrow))
			{
				//gameObject.transform.localEulerAngles.y;
				transform.Rotate(new Vector3(0, 1.0f, 0));//1フレームごとに0.5度回転
				/*
				rotateObject.GetComponent<Rotate>().AddRotate();
				int yrotate = script.yrotate;
				//int yrotate2 = script.yrotate2;
				Vector3 angle1 = new Vector3(0, yrotate, 0);
				transform.rotation = Quaternion.Euler(angle1);
				if(Input.GetKey(KeyCode.LeftArrow))
				{
					//Vector3 angle2 = new Vector3(0, yrotate2, 0);
					//transform.rotation = Quaternion.Euler(angle2);
					//rotateObject.GetComponent<Rotate>().AddRotate2();
					Debug.Log("l");
					gameObject.transform.localEulerAngles;
					transform.Rotate(new Vector3(0, -1.0f, 0f));
				}
				*/

			}

			if(angles[3] == "touching" && Input.GetKey(KeyCode.LeftArrow))
			{
				transform.Rotate(new Vector3(0, -1.0f, 0));
				Debug.Log("j");
			}
					
		} 
		catch (System.Exception e) {
			Debug.LogWarning(e.Message);
			
		}
	}
}