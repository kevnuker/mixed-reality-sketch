using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
	float distance = 10;
	float rotationSpeed = 10;

	void OnMouseDrag ()
	{
		drag ();
	}

	void OnCollisionEnter (Collision collision)
	{
		foreach (ContactPoint contact in collision.contacts) {
			Debug.Log (contact.point);
		}
		Rigidbody rBody = collision.gameObject.GetComponent (typeof(Rigidbody)) as Rigidbody;
		if (rBody != null) {
			FixedJoint fJoint = gameObject.AddComponent (typeof(FixedJoint)) as FixedJoint;
			fJoint.connectedBody = collision.rigidbody;
		}
	}

	void drag ()
	{
		Vector3 mousePosition = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, distance);
		Vector3 objPosition = Camera.main.ScreenToWorldPoint (mousePosition);

		transform.position = objPosition;
	}

	void rotate ()
	{
		float rotX = Input.GetAxis ("Mouse X") * rotationSpeed * Mathf.Deg2Rad;
		float rotY = Input.GetAxis ("Mouse Y") * rotationSpeed * Mathf.Deg2Rad;

		transform.RotateAround (Vector3.up, -rotX);
		transform.RotateAround (Vector3.right, rotY);
	}
}
