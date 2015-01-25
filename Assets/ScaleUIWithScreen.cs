using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScaleUIWithScreen : MonoBehaviour {

	float originalScale;
	CanvasScaler canvasScaler; 

	// Use this for initialization
	void Start () {
		canvasScaler = GetComponent<CanvasScaler>();
		originalScale = canvasScaler.scaleFactor;
	}
	
	// Update is called once per frame
	void Update () {
		if(Screen.width <= 0){
			canvasScaler.scaleFactor = 1;
		}
		else{
			canvasScaler.scaleFactor = originalScale * (((float)Screen.width)/1920);
		}

	}
}
