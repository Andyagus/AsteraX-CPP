using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffScreenWrapper : MonoBehaviour {

    Collider coll;

    private void Start()
    {
        coll = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("On Trigger Enter");
        //Debug.Log("enter " + other.name);
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    Debug.Log("closest point on bounds "+ coll.ClosestPointOnBounds(other.transform.position));

    //    //OnDrawGizmos(closestPoint);
        
    //    //Debug.Log(ClosestPointOnBounds)
    //    //Debug.Log("exit " + other.transform.position);
    //    //var scaledVector = Vector3.Scale(closestPoint, new Vector3(-1, -1, 1));
    //    //other.transform.position = scaledVector;
    //    //Debug.Log("exit " + other.name);
    //}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(new Vector3(-10.1f, 9.2f, 0f), 1);
    }


}
