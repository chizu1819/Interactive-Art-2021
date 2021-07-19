using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class retry : MonoBehaviour {

	// Use this for initialization
	public GameObject rule;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //ゲームオブジェクト表示→非表示
            rule.gameObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            //ゲームオブジェクト表示→非表示
            rule.gameObject.SetActive(false);
        }
		
	}
	public void OnButtonClicked(){
		SceneManager.LoadScene("main");
	}

}
