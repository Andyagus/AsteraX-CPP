using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class RotateTurret : Singleton<RotateTurret> {
    public GameObject turret;

    private Vector3 mousePos;
    public Vector3 aimDirection;


    private void Start()
    {
        AsteraX.instance.OnMousePos += OnMousePos;
    }

    private void OnMousePos(Vector3 mousePos)
    {
        this.mousePos = mousePos;
    }

    private void Update()
    {        
        aimDirection = (mousePos - transform.position).normalized;
        float radian = Mathf.Atan2(aimDirection.x, aimDirection.y);
        float angle = radian * Mathf.Rad2Deg;
        turret.transform.eulerAngles = new Vector3(0, 0, -angle);
        Debug.DrawLine(turret.transform.position, mousePos, new Color(Color.red.r, Color.red.g, Color.red.b, 0.3f));        
    }
}
