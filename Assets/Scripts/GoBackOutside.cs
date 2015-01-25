using UnityEngine;
using System.Collections;

public class GoBackOutside : MonoBehaviour {

	BoxCollider boxCol;
	Water water;
	GameObject player;

	// Use this for initialization
	void Start () {
		PlayerPrefs.DeleteKey("GotWater");
		boxCol = GetComponent<BoxCollider>();
		player = GameObject.FindGameObjectWithTag("Player");
		water = FindObjectOfType<Water>();
	}
	
	// Update is called once per frame
	void Update () {
		if(water.held){
			if(boxCol.bounds.Contains(player.transform.position)){
				Application.LoadLevel("Outdoors_Again");
				PlayerPrefs.SetInt("GotWater", 1);
			}
		}
	}
}
