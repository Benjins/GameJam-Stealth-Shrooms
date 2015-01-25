using UnityEngine;
using System.Collections;

public class ObjectTrans : MonoBehaviour {

	public float x, y, z;
	
	public bool Pulsing = false;
	public float Pulse_rate;

	float time = 0;
	
	void Pulse() {
		float var = Mathf.Sin (time) * Pulse_rate/100;
		transform.localScale += new Vector3 (var, var, var);
	}
	
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if(Time.timeScale > 0){
			transform.Rotate(new Vector3 (x, y, z));
		}
		if (Pulsing == true) {
			Pulse ();
		}
	}
}
