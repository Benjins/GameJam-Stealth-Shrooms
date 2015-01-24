using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathingNode : MonoBehaviour {

	public List<PathingNode> neighbors;
	public float sightRadius = 25.0f;
	public float parentRadius = 0.5f;

	[ContextMenu("Connect To Neighbors")]
	public void ConnectToNeighbors(){
		neighbors.Clear();

		//TODO: Potential for duplicate PathingNode's if they have multiple colliders
		Collider[] cols = Physics.OverlapSphere(transform.position, sightRadius);
		foreach(Collider col in cols){
			PathingNode node = col.GetComponent<PathingNode>();
			if(node != null){
				RaycastHit hit;
				if(Physics.Raycast(transform.position, node.transform.position - transform.position, out hit)){
					if(col == hit.collider){
						neighbors.Add(node);
					}
				}
			}
		}
	}

	void OnDrawGizmos(){
		Gizmos.color = Color.blue;
		Gizmos.DrawWireCube(transform.position, Vector3.one/2);
		foreach(PathingNode node in neighbors){
			Gizmos.DrawLine(transform.position, node.transform.position);
		}
	}
}
