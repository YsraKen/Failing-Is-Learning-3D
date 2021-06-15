using UnityEngine;
using System.Collections.Generic;

public class BackgroundRandomizer : MonoBehaviour
{
	#if UNITY_EDITOR
	
		public Transform
			areaA, areaB;
			
		[Header("Island Spawner")]
		public Island[] islandPrefabs;
		public List<Island> myIslands = new List<Island>();
		
		public Vector2Int islandSample = new Vector2Int(5, 20);
		public Vector2 spawnSize = new Vector2(0.5f, 2f);
		
		public List<float> discardedScales = new List<float>();
		
		[Header("Cloud Spawner")]
		public GameObject[] cloudPrefabs;
		public List<GameObject> myClouds = new List<GameObject>();
		
		public Vector2Int cloudSample = new Vector2Int(10, 30);
		public Vector2 cloudAltitude = new Vector2(20f, 40f);
	
	#endif
	
	void Awake(){
		Destroy(this);
	}
}