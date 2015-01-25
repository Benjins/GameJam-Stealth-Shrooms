using UnityEngine;
using System.Collections;

public class Campfire : MonoBehaviour {

	GameObject player;
	BoxCollider boxCol;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		boxCol = GetComponent<BoxCollider>();
	}
	
	// Update is called once per frame
	void Update () {
		if(PlayerPrefs.HasKey("GotWater")){
			if(boxCol.bounds.Contains(player.transform.position)){
				PlayerPrefs.DeleteKey("GotWater");
				Debug.Log("You win!");
			}
		}
	}
}
