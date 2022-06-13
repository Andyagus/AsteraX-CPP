//#define DEBUG_TurretPointAtMouse_DrawMousePoint

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPointAtMouse : MonoBehaviour {

    Vector3 mousePoint;

#if DEBUG_TurretPointAtMouse_DrawMousePoint
    public bool drawMousePoint = false;
#endif

	void Update () {
		PointAtMouse();
	}

	private void PointAtMouse()
    {
		mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition +
            Vector3.back * Camera.main.transform.position.z);
        transform.LookAt(mousePoint, Vector3.back);
    
    }

    //All debug code
#if DEBUG_TurretPointAtMouse_DrawMousePoint
    private void OnDrawGizmos()
    {

        if (Application.isPlaying && drawMousePoint)
        {
            Gizmos.color = Color.white;
            var size = new Vector3(1, 1, 1);
            Gizmos.DrawWireCube(mousePoint, size);
            Gizmos.DrawLine(transform.position, mousePoint);
        }

    }
#endif
}
