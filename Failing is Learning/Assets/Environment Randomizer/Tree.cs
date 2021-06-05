using UnityEngine;

public class Tree : MonoBehaviour
{
	#if UNITY_EDITOR
	
		// was moved to editor script
		/* public Tree Spawn(Vector3 position, Transform parent){
			var targetPosition = parent.TransformPoint(position);
			var targetRotation = Quaternion.Euler(Vector3.up * Random.Range(-180f, 180f));
			var targetScale = Vector3.one * Random.value;
					
			var newTree = Instantiate(
				this,
				targetPosition,
				targetRotation
			);
			
			newTree.transform.localScale = targetScale;
			newTree.transform.parent = parent;
			
			return newTree; 
		}*/
	
	#endif
	
	void Awake(){
		Destroy(this);
	}
}