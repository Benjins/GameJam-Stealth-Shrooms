using UnityEngine;
using System.Collections;

public class DogAI : MonoBehaviour {

	public float speed = 1.0f;
	public float rotationSpeed = 60.0f;
	public Vector3[] pathPoints = new Vector3[3]; 
	int currentPoint = 0;

	GameObject player;
	BoxCollider boxCol;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		boxCol = GetComponent<BoxCollider>();
	}
	
	// Update is called once per frame
	void Update () {
		if(boxCol.bounds.Contains(player.transform.position)){
			OnCaughtPlayer();
		}

		Vector3 goalDir = pathPoints[currentPoint] - transform.position;
		goalDir.y = 0;
		if(goalDir.magnitude < 0.5f){
			currentPoint = (currentPoint + 1) % pathPoints.Length;
		}

		Quaternion goalRotation = Quaternion.LookRotation(goalDir);
		transform.rotation = Quaternion.RotateTowards(transform.rotation, goalRotation, rotationSpeed * Time.deltaTime);
		transform.position += transform.forward * Time.deltaTime * speed;
	}

	void OnCaughtPlayer(){
		if(Time.timeScale > 0){
			GameOverScreen.instance.SetUI(true);
		}
	}

	void OnDrawGizmos(){
		Gizmos.color = Color.green;
		for(int i = 0; i < pathPoints.Length; i++){
			Gizmos.DrawWireSphere(pathPoints[i], 0.3f);
			Gizmos.DrawLine(pathPoints[i], pathPoints[(i + 1) % pathPoints.Length]);
		}
	}
}
