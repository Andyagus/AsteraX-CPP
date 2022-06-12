using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class ShipMovement : MonoBehaviour {


	float horizontalMovement;
	float verticalMovement;
	private float speed = 4;

	// Use this for initialization
	void Start () {
	}
	
	void Update () {

		CalculateInput();
		MoveShip();
	}

	private Vector3 CalculateInput()
    {
		horizontalMovement = CrossPlatformInputManager.GetAxis("Horizontal");
		verticalMovement = CrossPlatformInputManager.GetAxis("Vertical");
		Vector3 movementDirection = new Vector3(horizontalMovement, verticalMovement, 0);

		return movementDirection;
	}

	private void MoveShip()
    {
		var ship = gameObject.transform;
		var movementSpeed = CalculateInput().normalized * Time.deltaTime * speed;		
		ship.position += movementSpeed;
    }
}
