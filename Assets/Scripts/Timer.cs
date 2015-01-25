﻿using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	public static Timer instance;

	void Awake(){
		if(instance == null){
			instance = this;
		}

		if(instance != this){
			Destroy(gameObject);
		}
		else{
			DontDestroyOnLoad(gameObject);
		}
	}

	public float timeLeft = 300f;
	public int min, sec;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
		min = (int)(timeLeft / 60);
		sec = (int)(timeLeft - (min * 60));
	}

	void OnGUI(){
		GUI.contentColor = Color.red;
		GUI.skin.label.fontSize = 20;
		int x = (int)(Screen.width * .87);
		int y = (int)(Screen.height * .84);
		GUI.Label (new Rect (x, y, 100, 30), min.ToString() +" : " + sec.ToString());

	}
}
