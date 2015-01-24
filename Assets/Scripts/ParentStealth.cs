using UnityEngine;
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
		transform.localScale = Vector3.one * 1;
		Vector3 playerDirection = player.transform.position - transform.position;
		playerDirection.y = 0; //We don't care about vertical offset
		if(playerDirection.magnitude < sightDistance){
			float playerDotProduct = Vector3.Dot(transform.forward, playerDirection.normalized);
			if(-playerDotProduct < Mathf.Cos(fieldOfView)){
				Debug.Log("Big.");
				transform.localScale = Vector3.one * 2;
			}
		}
	}
}
