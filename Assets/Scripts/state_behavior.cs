using UnityEngine;
using System.Collections;

public enum object_state {visible_real, invisible_real, invisible_imaginary, visible_imaginary}

public class state_behavior : MonoBehaviour {
	public object_state starting_state; 
	float elapsed_time; // seconds spent in current state
	const float state_duration = 20.0f; // in seconds
	object_state current_state; // current state

	// Use this for initialization
	void Start () {
		this.current_state = this.starting_state;
		elapsed_time = 0;
		render_state ();
		// set colider, which is constant for object
		if (this.current_state == object_state.visible_real || 
		    	this.current_state == object_state.invisible_real) {
			this.collider.enabled = true;
		} else if (this.current_state == object_state.visible_imaginary ||
		           this.current_state == object_state.invisible_imaginary) {
			this.collider.enabled = false;
		}
	}


	// Update is called once per frame
	void Update () {
		if (this.elapsed_time >= state_duration) {
			transition_state ();
		}
		if (this.current_state == object_state.visible_real || 
		    	this.current_state == object_state.invisible_real) {
			int trip_intensity = 0; // change later
			int num = Random.Range(1,100);
			if (num < trip_intensity) {
				transition_state();
			}
		}
		this.elapsed_time += Time.deltaTime;
	}
	 
	void transition_state() {
		this.elapsed_time = 0; // new state
		if (this.current_state == object_state.visible_real) {
			this.current_state = object_state.invisible_real; 
		} else if (this.current_state == object_state.invisible_real) {
			this.current_state = object_state.visible_real;
		} else if (this.current_state == object_state.invisible_imaginary) {
			this.current_state = object_state.visible_imaginary;
		} else if (this.current_state == object_state.visible_imaginary) {
			this.current_state = object_state.invisible_imaginary;
		}
		render_state ();
	}


	void render_state() {
		if (this.current_state == object_state.visible_real ||
		    	this.current_state == object_state.visible_imaginary) {
			this.renderer.enabled = true;
		} else if (this.current_state == object_state.invisible_real ||
		           this.current_state == object_state.invisible_imaginary) {
			this.renderer.enabled = false;
		}
	}
}
