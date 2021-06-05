using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
	public static LevelLoader instance{ get; private set; }
	void Awake(){ instance = this; }
	
	public LevelLoad_Manager levelLoadMgr;
	
	DataManager dataMgr;
	SceneLoader sceneLoader;
	
	void Start(){
		dataMgr = DataManager.instance;
		sceneLoader = GetComponent<SceneLoader>();
	}
	
	// Dynamic Level load (resume the level from data, or load a very first level for new game)
	public void GoToLevel(){
		int levelIndex = dataMgr.currentData.currentLevelIndex;
		var level = levelLoadMgr.GetLevel(levelIndex);
		
		sceneLoader.Load(level);
	}
	
	// manually load the level by levelIndex (not buildIndex)
	public void Load(int levelIndex){
		var level = levelLoadMgr.GetLevel(levelIndex);
		sceneLoader.Load(level);
	}
	
	public void Reload(){
		int sceneIndex = SceneManager.GetActiveScene().buildIndex;
		sceneLoader.Load(sceneIndex);
	}
}