using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltWithVelocity : MonoBehaviour {
    public int degrees = 30;
    public bool tiltTowards = true;

    private int prevDegrees = int.MaxValue;
    private float tan;

    Rigidbody shipRb;

    private void Start()
    {
        shipRb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //dont completely understand
        if (degrees != prevDegrees)
        {
            prevDegrees = degrees;
            tan = Mathf.Tan(Mathf.Deg2Rad * degrees);
        }

        Vector3 pitchDir = tiltTowards ? -shipRb.velocity : shipRb.velocity;
        pitchDir += Vector3.forward / tan * PlayerShip.instance.shipSpeed;
        transform.LookAt(transform.position + pitchDir);
    }
}
