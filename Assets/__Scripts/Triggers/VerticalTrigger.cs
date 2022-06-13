using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
		Debug.Log("Trigger " + other);
		FlipPosition(other.gameObject);
    }

	private void FlipPosition(GameObject other)
    {
		other.transform.position = Vector3.Scale(other.transform.position, new Vector3(-1, 1, 1));
    }
}
