using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class RotateTurret : Singleton<RotateTurret> {
    public GameObject turret;

    public Vector3 aimDirection; 

    
    private void Update()
    {
        var mousePos = ShipMovement.instance.mousePos;
        aimDirection = (mousePos - transform.position).normalized;
        float radian = Mathf.Atan2(aimDirection.x, aimDirection.y);
        float angle = radian * Mathf.Rad2Deg;
        turret.transform.eulerAngles = new Vector3(0, 0, -angle);
        Debug.DrawLine(turret.transform.position, mousePos, new Color(Color.red.r, Color.red.g, Color.red.b, 0.3f));
    }
}
