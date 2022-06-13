using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffScreenWrapper : MonoBehaviour {
	
	void Update () {
		
	}


    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit trigger");
        //stop wrapping if script is disabled
        if (!enabled)
        {
            return;
        }

        ScreenBounds bounds = other.GetComponent<ScreenBounds>();
        if(bounds == null)
        {
            return;
        }

        ScreenWrap(bounds);
    }

    private void ScreenWrap(ScreenBounds bounds)
    {       
        var relativeLocation = bounds.transform.InverseTransformPoint(transform.position);
        if (Mathf.Abs(relativeLocation.x) > 0.5f)
        {
            relativeLocation.x *= -1;
        }
        if (Mathf.Abs(relativeLocation.y) > 0.5)
        {
            relativeLocation.y *= -1;
        }
        transform.position = bounds.transform.TransformPoint(relativeLocation);
    }

}
