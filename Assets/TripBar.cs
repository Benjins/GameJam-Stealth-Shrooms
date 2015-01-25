using UnityEngine;
using System.Collections;

public class TripBar : MonoBehaviour {
	public Trip_state_manager manager;

	private float start_y;
	private float y_range;
	public float test_y;
	//private RectTransform tripLevelTransform = new RectTransform();
	private Vector3 posn_vector;

	// Use this for initialization
	void Start () {
		start_y = transform.position.y;
		manager = FindObjectOfType<Trip_state_manager> ();
		posn_vector = new Vector3 ( transform.position.x , start_y, transform.position.z);
		//tripLevelTransform.position = posn_vector;
	}
	
	// Update is called once per frame
	void Update () {
		posn_vector.y = start_y + 295f / 100f * manager.tripLevel;
		transform.position = posn_vector; 
	}
}
