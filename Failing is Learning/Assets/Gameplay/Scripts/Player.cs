using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
	#region Singletons
		
		public static Player instance{ get; private set; }
		void Awake(){ instance = this; }
	
		DataManager dataMgr;
		void Start(){ dataMgr = DataManager.instance; }
	
	#endregion
	
	public int life{ // it will be saved along with LevelManager
		get{ return dataMgr.currentData.livesRemaining; }
		set{ dataMgr.currentData.livesRemaining = value; }
	}
	
	public UnityEvent
		onDeath = new UnityEvent(), // target listener: PlayerManager Die
		onRespawn = new UnityEvent();
	
	public void Damage(){
		life --;
		
		if(life <= 0)
			onDeath?.Invoke();
	}
	
	public void Respawn(){
		onRespawn?.Invoke();
	}
	
	#region Shortcuts
	
		public Vector3 position{
			get{ return transform.position; }
			set{ transform.position = value; }
		}
		
		public Quaternion rotation{
			get{ return transform.rotation; }
			set{ transform.rotation = value; }
		}
		
		public void SetActive(bool activeSelf){
			gameObject.SetActive(activeSelf);
		}
	
	#endregion
	
	
}