using UnityEngine;
using System.Collections;

public class AnimatedTexture : MonoBehaviour {

	public Texture[] frames;
	public int frameRate = 12;

	float elapsedTime = 0.0f;
	int frame = 0;

	// Use this for initialization
	void Start () {
		renderer.material.mainTexture = frames[0];
	}
	
	// Update is called once per frame
	void Update () {
		int newFrame = Mathf.FloorToInt(elapsedTime * frameRate);
		newFrame = newFrame % frames.Length;
		if(frame != newFrame){
			renderer.material.mainTexture = frames[frame];
			frame = newFrame;
		}

		elapsedTime += Time.deltaTime;
	}
}
