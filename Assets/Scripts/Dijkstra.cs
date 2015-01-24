using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Dijkstra {

	public static Stack<Vector3> DijkstraAlg(PathingNode start, PathingNode end, PathingNode[] graph){
		Dictionary<PathingNode,float> dist = new Dictionary<PathingNode, float>();
		Dictionary<PathingNode,PathingNode> prev = new Dictionary<PathingNode, PathingNode>();
		List<PathingNode> Q = new List<PathingNode>();

		dist[start] = 0;
		prev[start] = null;

		foreach(PathingNode node in graph){
			if(node != start){
				dist[node] = Mathf.Infinity;
				prev[node] = null;
			}

			Q.Add(node);
		}

		while(Q.Count > 0){
			PathingNode u = null;
			float minDist = Mathf.Infinity;
			foreach(PathingNode node in Q){
				if(dist[node] < minDist){
					minDist = dist[node];
					u = node;
				}
			}

			if(u == end){
				Stack<Vector3> path = new Stack<Vector3>();
				PathingNode curr = end;
				while(curr != null){
					path.Push(curr.transform.position);
					curr = prev[curr];
				}

				return path;
			}

			Q.Remove(u);

			foreach(PathingNode neigh in u.neighbors){
				float alt = dist[u] + (u.transform.position - neigh.transform.position).magnitude;
				if(alt < dist[neigh]){
					dist[neigh] = alt;
					prev[neigh] = u;
				}
			}
		}

		return null;
	}
}
