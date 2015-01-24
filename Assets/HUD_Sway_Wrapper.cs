using UnityEngine;
using System.Collections;

public class HUD_Sway_Wrapper : MonoBehaviour {
	public MouseLook mouse_look;
	// Use this for initialization
	void Start () {
		mouse_look = FindObjectOfType<MouseLook> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
