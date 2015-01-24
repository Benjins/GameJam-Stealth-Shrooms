using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ParentPathing : MonoBehaviour {
	public float speed = 3.0f;
	public float rotationSpeed = 60.0f;
	Vector3 immediateTarget;

	Stack<Vector3> pathingPoints;

	PathingNode pathingGoal;
	PathingNode currentNode;
	PathingNode[] nodes;

	// Use this for initialization
	void Start () {
		nodes = FindObjectsOfType<PathingNode>();
		RecalculateCurrentNode();
		GetRandomGoalNode();
		RecalculatePath();
		immediateTarget = pathingPoints.Pop();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 goalDirection = immediateTarget - transform.position;
		Quaternion goalRotation = Quaternion.LookRotation(goalDirection);
		transform.rotation = Quaternion.RotateTowards(transform.rotation, goalRotation, rotationSpeed*Time.deltaTime);
		transform.position += transform.forward * Time.deltaTime *speed;

	}

	public void RecalculateCurrentNode(){
		float closestDistSqr = Mathf.Infinity;
		PathingNode closestNode = null;
		foreach(PathingNode node in nodes){
			float distSqr = (transform.position - node.transform.position).sqrMagnitude;
			if(distSqr < closestDistSqr){
				closestNode = node;
				closestDistSqr = distSqr;
			}
		}

		currentNode = closestNode;
	}

	public void GetRandomGoalNode(){
		int index = Random.Range(0,nodes.Length);
		if(nodes[index] == currentNode){
			index = (index + 1) % nodes.Length;
		}
		pathingGoal = nodes[index];
	}

	public void RecalculatePath(){
		pathingPoints = Dijkstra.DijkstraAlg(currentNode,pathingGoal,nodes);
		immediateTarget = pathingPoints.Pop();
	}

	void OnTriggerEnter(Collider col){
		if((transform.position - immediateTarget).magnitude < 2){
			PathingNode node = col.gameObject.GetComponent<PathingNode>();
			if(node != null){
				RecalculateCurrentNode();
				if(node == pathingGoal){
					GetRandomGoalNode();
					RecalculatePath();
					immediateTarget = pathingPoints.Pop();
				}
				else{
					RecalculateCurrentNode();
					immediateTarget = pathingPoints.Pop();
				}
			}
		}
	}
}
