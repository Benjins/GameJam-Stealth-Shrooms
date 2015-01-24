using UnityEngine;
using System.Collections;

public class PlayerStillness : MonoBehaviour {

	public float maxDistance = 0.1f;
	public float minStillTime = 5.0f;
	public float maxStillTime = 15.0f;
	public float maxTripLowering = 10.0f;
	public float tripTimeout = 20.0f;

	public float testTripMeter = 50.0f;

	bool timedOut = false;
	Vector3 previousPosition;
	float currentStillTime = 0.0f;


	// Use this for initialization
	void Start () {
		previousPosition = transform.position;
	}

	void LateUpdate(){
		if(timedOut){
			return;
		}
		if((transform.position - previousPosition).magnitude < maxDistance){
			currentStillTime += Time.deltaTime;
			if(currentStillTime > minStillTime){
				if(currentStillTime > maxStillTime){
					timedOut = true;
					Invoke("ResetTimeout", tripTimeout);
				}
				else{
					testTripMeter -= maxTripLowering * (Time.deltaTime/(maxStillTime - minStillTime));
				}

			}
		}
		else{
			currentStillTime = 0;
			previousPosition = transform.position;
		}
	}

	void ResetTimeout(){
		timedOut = false;
	}
}
