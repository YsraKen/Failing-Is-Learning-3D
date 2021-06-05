using UnityEngine;
using UnityEngine.UI;

// This Script is Subscibed on Player Manager Events

public class HUD : MonoBehaviour
{
	public Text playerLifeText;
	
	PlayerManager playerMgr;
	Player player;
	
	void Start(){
		playerMgr = PlayerManager.instance;
		player = Player.instance;
		
			playerMgr.events.onPlayerDamaged += OnPlayerDamaged;
			
		// Update UI
			playerLifeText.text = player.life.ToString();
	}
	
	void OnPlayerDamaged(){
		// Update Health UI
		playerLifeText.text = player.life.ToString();
	}
}