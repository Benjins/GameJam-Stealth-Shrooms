using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Water : MonoBehaviour {

	public bool held = false;
	public GameObject waterPrefab;
	public AudioClip waterDrinking;

	Trip_state_manager tripManager;
	GameObject player;
	GameObject waterInstance;

	BoxCollider boxCol;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		waterInstance = Instantiate(waterPrefab) as GameObject;
		boxCol = GetComponent<BoxCollider>();
		tripManager = FindObjectOfType<Trip_state_manager>();
	}
	
	// Update is called once per frame
	void Update () {
		if(boxCol.bounds.Contains(player.transform.position)){
			held = true;
		}

		if(held && Input.GetKeyUp(KeyCode.F)){
			//Drink the water
			tripManager.tripLevel = Mathf.Clamp(tripManager.tripLevel - 25, 0, 100);
			held = false;
			audio.PlayOneShot(waterDrinking);
		}

		if(held){
			waterInstance.transform.position = player.transform.position + player.transform.forward;
			waterInstance.SetActive(true);
		}
		else{
			waterInstance.SetActive(false);
		}
	}
}
