using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class RotateTurret : MonoBehaviour {
    public GameObject turret;

    
    private void Update()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(CrossPlatformInputManager.mousePosition);
        Vector3 direction = (mousePos - transform.position).normalized * 100;

        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation.= Quaternion.Euler(angle, Vector3.forward);
        
        Debug.DrawLine(this.gameObject.transform.position, mousePos, Color.red);
        
    }
}
