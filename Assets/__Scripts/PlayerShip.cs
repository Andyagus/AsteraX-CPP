//#define DEBUG_ShotDistance

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(Rigidbody))]
public class PlayerShip : Singleton<PlayerShip>
{
    public GameObject bulletPrefab;
    public float shipSpeed = 10f;
    private Rigidbody shipRb;

    private Vector3 mousePos;


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

        //Mouse input for firing
        if (CrossPlatformInputManager.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }

    private void Fire()
    {
        
        var mousePosition = Input.mousePosition;
        mousePosition.z -= Camera.main.transform.position.z;
        var mousePosition3D = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePos = mousePosition3D;


        GameObject bullet = Instantiate<GameObject>(bulletPrefab);
        bullet.transform.position = transform.position;
        bullet.transform.LookAt(mousePosition3D);

    }

#if DEBUG_ShotDistance
    private void OnDrawGizmos()
    {
        if (Application.isPlaying)
        {
            Gizmos.color = Color.white;
            Gizmos.DrawLine(transform.position, mousePos);
        }
    }
#endif

}
