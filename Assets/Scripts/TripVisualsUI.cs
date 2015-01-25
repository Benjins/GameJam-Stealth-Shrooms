using UnityEngine;
using System.Collections;

public class TripVisualsUI : MonoBehaviour {

	public GameObject[] visuals;

	public float tripTimeMin = 10.0f;
	public float tripTimeMax = 30.0f;

	public float tripLevel = 0.0f;
	public float minTripLevel = 1.0f;
	public float maxTripLevel = 100.0f;

	public float minTripSize = 0.3f;
	public float maxTripSize = 2.0f;

	float currentTime = 0.0f;
	float timeToNextTrip = 0.0f;

	// Use this for initialization
	void Start () {
		//AddTripVisual();
		//AddTripVisual();
		float percentTripping = (tripLevel-minTripLevel)/(tripLevel-maxTripLevel);
		timeToNextTrip = Mathf.Lerp(tripTimeMax,tripTimeMin,percentTripping);
	}
	
	// Update is called once per frame
	void Update () {
		if(tripLevel < minTripLevel){
			return;
		}

		float percentTripping = Mathf.Clamp01((tripLevel-minTripLevel)/(maxTripLevel - minTripLevel));
		currentTime += Time.deltaTime * percentTripping; 
		if(currentTime >= timeToNextTrip){
			AddTripVisual();
			timeToNextTrip = Random.Range(tripTimeMin, tripTimeMax);
			currentTime = 0;
		}
	}

	void AddTripVisual(){
		Vector3 offset = new Vector3(Random.Range(-3.0f,3.0f), Random.Range(-2.0f,2.0f), 0);
		GameObject visual = Instantiate(visuals[Random.Range(0, visuals.Length)], transform.position + transform.forward + offset, Quaternion.identity) as GameObject;
		visual.transform.localScale = Vector3.one * Random.Range(minTripSize, maxTripSize);
		visual.transform.parent = transform;
	}
}
