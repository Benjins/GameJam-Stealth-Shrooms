using UnityEngine;
using System.Collections;

public class TripVisual : MonoBehaviour {

	public float timeOnScreen = 10.0f;
	public float fadeInTime = 1.0f;
	public float fadeOutTime = 1.0f;
	public float speed = 1.0f;

	float timeElapsed = -20.0f;

	void Start(){
		renderer.material.color = new Color(1, 1, 1, 0);
		StartCoroutine(FadeIn());
	}

	// Update is called once per frame
	void Update () {
		Vector3 moveDir = Random.insideUnitSphere * Time.deltaTime * speed;
		moveDir.z = 0;
		transform.localPosition += moveDir;
		timeElapsed += Time.deltaTime;

		if(timeElapsed >= timeOnScreen){
			StartCoroutine(FadeOut());
		}
	}

	IEnumerator FadeOut(){
		float timeSoFar = 0.0f;
		while(timeSoFar < fadeOutTime){
			timeSoFar += Time.deltaTime;
			renderer.material.color = new Color(1, 1, 1, Mathf.Pow(1-(timeSoFar/fadeOutTime), 2));
			yield return null;
		}

		Destroy(gameObject);
	}

	IEnumerator FadeIn(){
		float timeSoFar = 0.0f;
		while(timeSoFar < fadeInTime){
			timeSoFar += Time.deltaTime;
			renderer.material.color = new Color(1, 1, 1, Mathf.Pow((timeSoFar/fadeInTime), 2));
			yield return null;
		}
		
		timeElapsed = 0;
	}
}
