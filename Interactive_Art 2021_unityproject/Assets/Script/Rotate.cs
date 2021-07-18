using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {
	public　int yrotate = 0;
	public　int yrotate2 = 0;
    public void AddRotate()
    {
    	yrotate += 1;
    }
	public void AddRotate2()
    {
		yrotate -= 1;
    }
 
    void Update()
    {
    }
}
