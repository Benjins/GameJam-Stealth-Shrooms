using UnityEngine;
using System.Collections;

public class GrowWithTripLevel : MonoBehaviour {

	public float startScale = 1.0f;
	public float endScale = 5.0f;

	Trip_state_manager tripManager;

	// Use this for initialization
	void Start () {
		tripManager = FindObjectOfType<Trip_state_manager>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale = Vector3.one * Mathf.Lerp(startScale, endScale, tripManager.tripLevel/100);
	}
}
