﻿using UnityEngine;
using System.Collections;

public class ParentStealth : MonoBehaviour {

	public float sightDistance = 10.0f;
	public float fieldOfView = 60.0f;
	public GameObject visionCone;

	GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		if(visionCone == null){
			visionCone = transform.GetChild(0).gameObject;
		}
	}
	
	// Update is called once per frame
	void Update () {
		float cosHalfFOVAngle = Mathf.Cos(fieldOfView/2*Mathf.Deg2Rad);
		Vector3 newConeScale = new Vector3(cosHalfFOVAngle*2, sightDistance, cosHalfFOVAngle*2);
		visionCone.transform.localScale = newConeScale;

		transform.localScale = Vector3.one * 1;
		Vector3 playerDirection = player.transform.position - transform.position;
		playerDirection.y = 0; //We don't care about vertical offset
		if(playerDirection.magnitude < sightDistance){
			float playerDotProduct = Vector3.Dot(transform.forward, playerDirection.normalized);
			if(playerDotProduct > cosHalfFOVAngle){
				transform.localScale = Vector3.one * 2;
			}
		}
	}
}
