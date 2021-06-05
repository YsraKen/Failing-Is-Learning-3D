using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class PlayerManager : MonoBehaviour
{
	// Singleton
		public static PlayerManager instance{ get; private set; }
		void Awake(){ instance = this; }
		
	public GameObject corpse;
	public float respawnTimer = 2f;
	
	Player player;
	Vector3 spawnPosition; // to be assigned on startup (the place where the level designer placed the player object)
	bool isPlayerDead;
	
	#region Events
		
		[System.Serializable]
		public class EventWrapper{
			public UnityEvent
				_onPlayerDamaged = new UnityEvent(),
				_onPlayerRespawn = new UnityEvent(),
				_onPlayerDeath = new UnityEvent();
				
			public delegate void OnPlayerUpdateCallback();
			
			public OnPlayerUpdateCallback
				onPlayerDamaged,
				onPlayerRespawn,
				onPlayerDeath;
				
			public void OnPlayerDamaged(){
				_onPlayerDamaged?.Invoke();
				onPlayerDamaged?.Invoke();
			}
			
			public void OnPlayerRespawn(){
				_onPlayerRespawn?.Invoke();
				onPlayerRespawn?.Invoke();
			}
			
			public void OnPlayerDeath(){
				_onPlayerDeath?.Invoke();
				onPlayerDeath?.Invoke();
			}
		}
		
		public EventWrapper events = new EventWrapper();
	
	#endregion
	
	void Start(){
		player = Player.instance;
		spawnPosition = player.position;
	}
	
	public void Damage(){
		// create a new dead object on player's position
		// Debug.Log("Player Died!");
		
		var position = player.position;
		var rotation = player.rotation;
			
			Instantiate(corpse, position, rotation);
		
		player.Damage();
		player.SetActive(false);
		
		if(!isPlayerDead)
			StartCoroutine(RespawnRoutine()); // timer
			
		events.OnPlayerDamaged();
	}
	
	#region Respawn
	
		IEnumerator RespawnRoutine(){
			yield return new WaitForSeconds(respawnTimer);
			Respawn();
		}
		
		void Respawn(){
			player.position = spawnPosition;
			player.SetActive(true);
			
			player.Respawn();
			events.OnPlayerRespawn();
		}
	
	#endregion
	
	public void Die(){
		isPlayerDead = true;
		Debug.Log("Player Died");
		
		events.OnPlayerDeath();
	}
}