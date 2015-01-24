using UnityEngine;
using System.Collections;

public class trip_object : MonoBehaviour {
	const float visuals_start_level = 15;
	float shared_time = 20f; 
	float trip_time;   
	float sober_time;
	float time_in_current_state;
	public bool is_real;
	[HideInInspector]
	public float trip_level;
	bool in_trip;

	// Use this for initialization
	void Start () {
		this.shared_time = 20f;
		this.trip_level = 0f;
		this.sober_time = shared_time; // sober object to start 
		this.trip_time = 0;
		this.in_trip = false;
		this.time_in_current_state = 0; // just started, sober
		this.collider.enabled = this.is_real; // if the obj is real, you can run into it
	}
	
	// Update is called once per frame
	void Update () {
		// get current trip level
		// modify, trip time and sober time achordingly
		if (this.trip_level >= visuals_start_level && !this.in_trip &&
		    this.time_in_current_state >= this.sober_time) { 
			int num = Random.Range(1,100);
			if (this.trip_level > num) { 
				start_trip();
				this.in_trip = true;
			} 
		} else if (this.in_trip && this.time_in_current_state >= trip_time
		           && trip_level <= 95f) { // done tripping
			stop_trip();
			this.in_trip = false;
		}
		time_in_current_state += Time.deltaTime; 
	}


	void stop_trip() {
		// change time ratio, i
		this.trip_time = (trip_level / 100) * shared_time;
		this.sober_time = (1 - (trip_level / 100)) * shared_time;
		this.time_in_current_state = 0; // new state
		if (this.is_real) {
			this.renderer.enabled = true; // you can see the real object again
		} else {
			this.renderer.enabled = false; // you don't see the hallucination
		}
	}

	
	void start_trip() {
		this.time_in_current_state = 0; 
		if (this.is_real) {
			this.renderer.enabled = false; // you can't see something that's there
		} else {
			this.renderer.enabled = true; // you see something that's not there
		}
	}
}
