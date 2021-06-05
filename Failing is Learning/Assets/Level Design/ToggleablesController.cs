using UnityEngine;

public class ToggleablesController : MonoBehaviour
{
	// Just to avoid UnityEvents for multiple same objects
	
	public Toggleables[] toggleables;
	
	public void Toggle(bool toggle){
		foreach(var t in toggleables)
			t.Toggle(toggle);
	}
}