using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
	static AudioManager _mgr;
	protected static AudioManager mgr{
		get{
			if(!_mgr) _mgr = AudioManager.instance;
			return _mgr;
		}
	}
	
	protected virtual void Start(){
		
	}
	
	public string[] audioNames;
	
	public void Play(string name){
		mgr.Play(name);
	}
	
	public void Play(int index){
		// mgr.Play(index);
		Play(audioNames[index]);
	}
}