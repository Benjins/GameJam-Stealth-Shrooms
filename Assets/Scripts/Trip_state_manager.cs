using UnityEngine;
using System.Collections;


public class Trip_state_manager : MonoBehaviour {
	public static Trip_state_manager instance;

	public int WASDMode = 0;
	public float tripLevel = 0;
//test
	public float rot_z = 0;

	public FPSInputController fps_control;
	public MouseLook mouse_look;
	public FOV_pulse fov_controller;

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

	// Use this for initialization
	void Start () {
		fps_control = FindObjectOfType<FPSInputController> ();
		//mouse_look = FindObjectOfType<MouseLook> ();
	}

	void OnTriggerEnter ( Collider other ) {
		if (other.gameObject.tag == "Trip_up") {
			if(tripLevel < 100) {
				//tripLevel += 25;
			}
			SetWASDMode (fps_control);
		}
	}

	// Update is called once per frame
	void Update () {
		tripLevel = Mathf.Clamp (tripLevel, 0, 100);

		SetWASDMode (fps_control); 

		//SetHUDSway (mouse_look);
	}
/*
	void SetHUDSway (MouseLook mouse_look) {
		mouse_look.rotationZ = 40 * tripLevel / 100;
	}
*/
	void SetWASDMode (FPSInputController fps_control) {
		if (fps_control != null) {
						fps_control.WASDMode = (int)tripLevel / 25;
				}
	}
}



/*
Trip_state_manager manager;

	Starert()
	get the manager


manager.tripLevel 
*/