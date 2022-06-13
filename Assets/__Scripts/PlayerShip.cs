using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(Rigidbody))]
public class PlayerShip : Singleton<PlayerShip>
{
    public float shipSpeed = 10f;
    private Rigidbody shipRb;

    private void Start()
    {
        shipRb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        MoveShip();
    }

    private void MoveShip()
    {
        var horizontalInput = CrossPlatformInputManager.GetAxis("Horizontal");
        var verticalInput = CrossPlatformInputManager.GetAxis("Vertical");

        var vel = new Vector3(horizontalInput, verticalInput);

        if (vel.magnitude > 0)
        {
            vel.Normalize();
        }

        shipRb.velocity = vel * shipSpeed * Time.deltaTime;
    }

}
