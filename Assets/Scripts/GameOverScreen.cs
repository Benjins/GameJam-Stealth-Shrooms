﻿using UnityEngine;
using System.Collections;

public class GameOverScreen : MonoBehaviour {
	
	public Color32 backgroundColor = new Color32(25,25,25,200);

	public bool showUI = false;
	Texture2D background;

	void Awake(){

	}

	// Use this for initialization
	void Start () {
		background = new Texture2D(2,2);
		background.SetPixels32(new Color32[4]{backgroundColor,backgroundColor,backgroundColor,backgroundColor});
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.Escape)){
			ToggleUI();
		}	
	}

	public void ToggleUI(){
		if(Time.timeScale > 0){
			Time.timeScale = 0;
			Time.fixedDeltaTime = 0;
		}
		else{
			Time.timeScale = 1;
			Time.fixedDeltaTime = 0.02f;
		}
		showUI = !showUI;
	}

	void OnGUI(){
		if(showUI){
			Rect rect = new Rect(Screen.width*0.1f,Screen.height*0.1f,Screen.width*0.8f,Screen.height*0.8f);
			GUI.Box(rect,background);
			GUILayout.BeginArea(rect);
			{
				GUI.skin.label.fontSize = 48;
				GUI.skin.button.fontSize = 48;
				GUILayout.Label("You have lost...");
				if(GUILayout.Button("Try Again?", GUILayout.Height(200))){
					Application.LoadLevel(Application.loadedLevel);
				}
			}
			GUILayout.EndArea();
		}
	}
}
