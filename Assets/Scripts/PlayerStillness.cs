using UnityEngine;
using System.Collections;

public class PlayerStillness : MonoBehaviour {

	public float maxDistance = 0.1f;
	public float minStillTime = 5.0f;
	public float maxStillTime = 15.0f;
	public float maxTripLowering = 10.0f;
	public float tripTimeout = 20.0f;

	public float testTripMeter = 50.0f;
	public float tripSpeed = 0.5f;

	Trip_state_manager tripManager;

	bool timedOut = false;
	Vector3 previousPosition;
	float currentStillTime = 0.0f;


	// Use this for initialization
	void Start () {
		previousPosition = transform.position;
		tripManager = FindObjectOfType<Trip_state_manager>();
	}

	void LateUpdate(){
		tripManager.tripLevel = Mathf.Clamp(tripManager.tripLevel+ Time.deltaTime * tripSpeed, 0, 100);
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
					float timePercent = (Time.deltaTime/(maxStillTime - minStillTime));
					tripManager.tripLevel = Mathf.Clamp(tripManager.tripLevel - Time.deltaTime  * tripSpeed, 0, 100);
					tripManager.tripLevel = Mathf.Clamp(tripManager.tripLevel - maxTripLowering * timePercent, 0, 100);
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
