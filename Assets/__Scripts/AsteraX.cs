using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class AsteraX : Singleton<AsteraX> {

	private Vector3 mousePos;
	public Action<Vector3> OnMousePos = (Vector3 mousePos) => { };


	void Update () {
		CalculateMousePos();	
	}


	private void CalculateMousePos()
	{
		mousePos = Camera.main.ScreenToWorldPoint(CrossPlatformInputManager.mousePosition);
		mousePos = new Vector3(mousePos.x, mousePos.y, 0);
		OnMousePos(mousePos);
	}

}
