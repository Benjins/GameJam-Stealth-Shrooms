using UnityEngine;
using System.Collections;

public class FOV_pulse : MonoBehaviour {
	public float FOV_pulse_rate = 0;
	public float FOV_pulse_range = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		camera.fieldOfView = 60 + Mathf.Cos (Time.time * FOV_pulse_rate) * FOV_pulse_range;
	}
}
