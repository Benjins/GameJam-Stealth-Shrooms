using UnityEngine;
using System.Collections;

public class trip_object : MonoBehaviour {
	const float visuals_start_level = 15;
	float shared_time = Random.Range(8, 30); 
	public float trip_time;   
	public float sober_time;
	public float time_in_current_state;
	public bool is_real;
	public float trip_level;
	[HideInInspector]

	bool in_trip;
	public Trip_state_manager manager;

	// Use this for initialization
	void Start () {
		manager = FindObjectOfType<Trip_state_manager> ();
		this.trip_level = 0f;
		this.sober_time = shared_time; //- Random.Range(1, 5); // sober object to start 
		this.trip_time = 0;
		this.in_trip = false;
		this.time_in_current_state = 0; // just started, sober
		this.collider.enabled = this.is_real; // if the obj is real, you can run into it
	}
	
	// Update is called once per frame
	void Update () {
		// get current trip level
		// modify, trip time and sober time achordingly
		trip_level = manager.tripLevel;

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
		this.trip_time = (trip_level / 20) * Random.Range(1, 5);
		this.sober_time = Random.Range (2, 12);//(1 - (trip_level / 100)) * shared_time;
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
