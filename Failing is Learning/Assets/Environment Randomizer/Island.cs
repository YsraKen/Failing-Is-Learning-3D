using UnityEngine;
using System.Collections.Generic;

public class Island : MonoBehaviour
{
	#if UNITY_EDITOR
	
		public Tree[] treePrefabs;
		public List<Tree> myTrees = new List<Tree>();
		
		public Mesh myMesh;
		public Vector3[] myVertices;
		
		// remember the used vertices
		[HideInInspector]
		public List<int> usedVertices_index = new List<int>();
				
		public Vector2Int sample = new Vector2Int(5, 20);
		public float waterLevel = 0.1f;
		
	#endif
	
	void Awake(){
		Destroy(this);
	}
}