using UnityEngine;
using System.Collections;

public class Water : MonoBehaviour {

	public bool held = false;

	GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.U)){
			held = !held;
		}
		if(held && Input.GetKeyUp(KeyCode.F)){
			//Drink the water
		}

		if(held){
			transform.position = player.transform.position + player.transform.forward;
		}
	}
}
