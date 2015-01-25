using UnityEngine;
using System.Collections;

public class BlinkLight : MonoBehaviour {

	public float minIntensity = 1.0f;
	public float maxIntensity = 1.5f;

	public float minRange = 10.0f;
	public float maxRange = 15.0f;

	public float lerpTime = 0.2f;

	bool lerping = false;
	float oldValue = 0.0f;

	// Update is called once per frame
	void Update () {
		if(!lerping){
			float value = Random.Range(0.0f, 1.0f);
			StartCoroutine(Flicker(value));
		}
	}

	IEnumerator Flicker(float lightValue){
		lerping = true;
		float time = 0;
		while(time < lerpTime){
			float value = Mathf.Lerp(oldValue, lightValue, time/lerpTime);
			light.intensity = Mathf.Lerp(minIntensity, maxIntensity, value);
			light.range = Mathf.Lerp(minRange, maxRange, value);
			time += Time.deltaTime;
			yield return null;
		}

		oldValue = lightValue;
		lerping = false;
	}
}
