using UnityEngine;
using System.Collections;

public class DogAI : MonoBehaviour {

	public float speed = 1.0f;
	public Vector3[] pathPoints = new Vector3[3]; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDrawGizmos(){
		Gizmos.color = Color.green;
		for(int i = 0; i < pathPoints.Length; i++){
			Gizmos.DrawWireSphere(pathPoints[i], 0.3f);
			Gizmos.DrawLine(pathPoints[i], pathPoints[(i + 1) % pathPoints.Length]);
		}
	}
}
