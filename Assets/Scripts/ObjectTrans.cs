using UnityEngine;
using System.Collections;

public class ObjectTrans : MonoBehaviour {

	public float x, y, z;
	
	public bool Pulsing = false;
	public float Pulse_rate;
	
	void Pulse() {
		float var = Mathf.Sin (Time.time) * Pulse_rate/100;
		transform.localScale += new Vector3 (var, var, var);
	}
	
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3 (x, y, z));
		if (Pulsing == true) {
			Pulse ();
		}
	}
}
