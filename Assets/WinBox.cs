using UnityEngine;
using System.Collections;

public class WinBox : MonoBehaviour {

	BoxCollider boxCol;
	GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		boxCol = GetComponent<BoxCollider>();
	}
	
	// Update is called once per frame
	void Update () {
		if(boxCol.bounds.Contains(player.transform.position)){
			Debug.Log("You Win!");
		}
	}
}
