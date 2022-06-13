using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerShip : MonoBehaviour { 

	Transform ship;
	float horizontalMovement;
	float verticalMovement;
	Vector3 movementDirection;
	private float speed = 4;

	public int inputMagnitude = 7;

	public Transform bulletPrefab;
	public Transform firePosition;

	public Action OnShotFired = () => { };
	public Action OnAimPos = () => { };

	private void Start()
	{
	}

	void Update()
	{
		CalculateInput();
		MoveShip();
		TiltInMovementDirection();
	}	
	
	private void CalculateInput()
	{
		horizontalMovement = CrossPlatformInputManager.GetAxis("Horizontal");
		verticalMovement = CrossPlatformInputManager.GetAxis("Vertical");
		movementDirection = new Vector3(horizontalMovement, verticalMovement, 0);

		if (CrossPlatformInputManager.GetAxis("Fire1") > 0) 
		{
			FireBullet();
		}
	}

	private void MoveShip()
	{
		ship = gameObject.transform;
		var movementSpeed = movementDirection.normalized * Time.deltaTime * speed;
		ship.position += movementSpeed;
	}

	private void TiltInMovementDirection()
	{
		var tiltDirection = new Vector3(movementDirection.y * inputMagnitude, -movementDirection.x * inputMagnitude, 0f);
		if (movementDirection != new Vector3(0, 0, 0))
		{
			ship.transform.rotation = Quaternion.Euler(tiltDirection);
		}
	}

	private void FireBullet()
	{
		var bullet = Instantiate(bulletPrefab, firePosition.position, bulletPrefab.transform.rotation);
	}
}
