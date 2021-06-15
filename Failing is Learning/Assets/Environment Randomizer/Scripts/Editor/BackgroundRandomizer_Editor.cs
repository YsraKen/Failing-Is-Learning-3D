using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BackgroundRandomizer))]
public class BackgroundRandomizer_Editor : Editor
{
	BackgroundRandomizer br;
	
	public override void OnInspectorGUI(){
		DrawDefaultInspector();
		br = (BackgroundRandomizer) target;
		
		if(GUILayout.Button("Spawn Objects")){
			// Spawn Islands
			int islandIteration = Random.Range(br.islandSample.x, br.islandSample.y);
			
			for(int i = 0; i < islandIteration; i++){
				var targetPosition = GetRandomPosition();
			
				var targetPrefab = br.islandPrefabs[Random.Range(0, br.islandPrefabs.Length)];
				var newIsland = SpawnIsland(targetPrefab, targetPosition);
					// targetPrefab.Spawn(targetPosition, br.transform);
				
				if(newIsland)
					br.myIslands.Add(newIsland);
			}
			
			// Spawn Clouds
			int cloudIteration = Random.Range(br.cloudSample.x, br.cloudSample.y);
			
			for(int i = 0; i < cloudIteration; i++){
				var targetPrefab = br.cloudPrefabs[Random.Range(0, br.cloudPrefabs.Length)];
				var newCloud = SpawnCloud(targetPrefab);
				
				if(newCloud)
					br.myClouds.Add(newCloud);
			}
		}
	}
	
	Vector3 GetRandomPosition(){
		return new Vector3(
			Random.Range(br.areaA.position.x, br.areaB.position.x),
			Random.Range(br.areaA.position.y, br.areaB.position.y),
			Random.Range(br.areaA.position.z, br.areaB.position.z)
		);
	}
	
	Island SpawnIsland(Island prefab, Vector3 position){
		var parent = br.transform;
		
		var targetPosition = parent.TransformPoint(position);
		var targetRotation = Quaternion.Euler(Vector3.up * Random.Range(-180f, 180f));
		// var targetScale = br.RandomizeScale(); 
		
		float minScale = br.spawnSize.x;
		float maxScale = br.spawnSize.y;
		
		float targetScale = Random.Range(0, maxScale);
		Island newIsland = null;
		
		if(targetScale >= minScale){
			newIsland = PrefabUtility.InstantiatePrefab(prefab) as Island;
			
			var t = newIsland.transform;
				t.position = targetPosition;
				t.rotation = targetRotation;
				t.localScale = targetScale * Vector3.one;
				t.parent = parent;
				
			SpawnTrees(newIsland);
		}else
			br.discardedScales.Add(targetScale);
		
		return newIsland;
	}
	
	GameObject SpawnCloud(GameObject prefab){
		var targetLocation = GetRandomPosition();
			targetLocation.y = br.transform.position.y;
				
		var targetAltitude = Vector3.up * Random.Range(br.cloudAltitude.x, br.cloudAltitude.x);
		
		float minScale = br.spawnSize.x;
		float maxScale = br.spawnSize.y;
		
		float targetScale = Random.Range(0, maxScale);
		GameObject newCloud = null;
		
		if(targetScale >= minScale){
			newCloud = PrefabUtility.InstantiatePrefab(prefab) as GameObject;
				
			var t = newCloud.transform;
				t.position = targetLocation + targetAltitude;
				t.rotation = Quaternion.identity;
				t.localScale = targetScale * Vector3.one;
				t.parent = br.transform;
		}
		
		return newCloud;
	}
	
	void SpawnTrees(Island island){
		int iteration = Random.Range(island.sample.x, island.sample.y);
		
		for(int i = 0; i < iteration; i++){
			int targetVertex_index = Random.Range(0, island.myVertices.Length);
			var vertex = island.myVertices[targetVertex_index];
			
			bool wasVertexUsed = island.usedVertices_index.Contains(targetVertex_index);
			bool isUnderwater = vertex.y < island.waterLevel;
			
			while(wasVertexUsed || isUnderwater){
				targetVertex_index = Random.Range(0, island.myVertices.Length);
				vertex = island.myVertices[targetVertex_index];
				
				wasVertexUsed = island.usedVertices_index.Contains(targetVertex_index);
				isUnderwater = vertex.y < island.waterLevel;
			}
			
			var targetPrefab = island.treePrefabs[Random.Range(0, island.treePrefabs.Length)];
			var newTree = NewTree(targetPrefab, vertex, island);
				// targetPrefab.Spawn(vertex, island.transform);
			
			if(newTree)
				island.usedVertices_index.Add(targetVertex_index);
				island.myTrees.Add(newTree);
		}
	}
	
	Tree NewTree(Tree prefab, Vector3 position, Island island){
		var parent = island.transform;
		var targetPosition = parent.TransformPoint(position);
		var targetRotation = Quaternion.Euler(Vector3.up * Random.Range(-180f, 180f)); // "-180f to 180f" is the universal default 360 degrees
		
		float minScale = island.spawnSize.x;
		float maxScale = island.spawnSize.y;
		
		float targetScale = Random.Range(0, maxScale);
		Tree newTree = null;
		
		if(targetScale >= minScale){
			newTree = PrefabUtility.InstantiatePrefab(prefab) as Tree;
		
			var t = newTree.transform;
				t.position = targetPosition;
				t.rotation = targetRotation;
				t.localScale = targetScale * Vector3.one;
				t.parent = parent;
		}
		else
			island.discardedScales.Add(targetScale);
		
		return newTree;
	}
}