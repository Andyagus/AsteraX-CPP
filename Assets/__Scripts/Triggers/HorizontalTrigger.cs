using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalTrigger : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        FlipPosition(other.gameObject);
    }

    private void FlipPosition(GameObject other)
    {
        other.transform.position = Vector3.Scale(other.transform.position, new Vector3(1, -1, 1));
    }
}
