﻿using UnityEngine;
using System.Collections;

public enum object_state {visible_real, invisible_real, invisible_imaginary, visible_imaginary}

public class state_behavior : MonoBehaviour {
	public object_state starting_state; 
	float elapsed_time; // seconds spent in current state
	float hallucination_durration = 2.0f; // in seconds
	float sober_durration = 10.0f;
	const int visuals_start_intensity = 15;
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
		// transition to hallucination if you are tripping hard enough
		// and sober state is over
		if (is_hallucination() == false) {
			int trip_intensity = 15; // change later
			if (trip_intensity >= visuals_start_intensity && 
			    this.elapsed_time >= this.sober_durration) {
				int num = Random.Range(1,100);
				if (trip_intensity > num) { 
					start_hallucination (); 
				} else { // stay in trip for a while longer
					this.sober_durration += 0.05f; // stay sober for longer
				}
			}
		} else if (this.elapsed_time >= this.hallucination_durration && is_hallucination()) {
			stop_hallucination ();
		}
		this.elapsed_time += Time.deltaTime;
	}


	bool is_hallucination() {
		if (this.current_state == object_state.visible_imaginary || 
		    this.current_state == object_state.invisible_real) {
				return true;
		} else {
			return false;
		}
	}
	 
	void stop_hallucination() {
		this.elapsed_time = 0; // new state
		if (this.current_state == object_state.invisible_real) {
			this.current_state = object_state.visible_real;
		} else if (this.current_state == object_state.visible_imaginary) {
			this.current_state = object_state.invisible_imaginary;
		}
		this.hallucination_durration += 4f; // so you hallucinate for longer next time
		render_state ();
	}

	void start_hallucination() {
		this.elapsed_time = 0; // new state
		if (this.current_state == object_state.visible_real) {
			this.current_state = object_state.invisible_real; 
		} else if (this.current_state == object_state.invisible_imaginary) {
			this.current_state = object_state.visible_imaginary;
		}
		this.sober_durration -= 1; // so your sober for a shorter time next
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
