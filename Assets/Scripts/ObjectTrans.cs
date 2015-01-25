using UnityEngine;
using System.Collections;

public class ObjectTrans : MonoBehaviour {

	public float x, y, z;
	
	public bool Pulsing = false;
	public float p_x, p_y, p_z;

	float time = 0;
	
	void Pulse() {
		transform.localScale += new Vector3 (Mathf.Sin (time) * p_x/100, Mathf.Sin (time) * p_y/100, Mathf.Sin (time) * p_z/100);
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
