using UnityEngine;
using System.Collections;

public class RotateCamera : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		transform.localRotation *= Quaternion.AngleAxis (45 * Time.deltaTime, Vector3.forward);
	}
}
