using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneLoader : MonoBehaviour
{
	public float delay = 1f;
	
	public void Load(string sceneName){
		// SceneManager.LoadScene(sceneName); // original
		StartCoroutine(LoadRoutine(sceneName)); // designed
	}
	
	public void Load(int sceneIndex){
		// SceneManager.LoadScene(sceneIndex); // original
		StartCoroutine(LoadRoutine(sceneIndex)); // designed
	}
	
	public void Quit(){
		// Application.Quit(); // original
		StartCoroutine(QuitRoutine()); // designed
	}
	
	#region Coroutines
	
		IEnumerator LoadRoutine(string sceneName){
			yield return new WaitForSecondsRealtime(delay);
			
			SceneManager.LoadScene(sceneName);
		}
		
		IEnumerator LoadRoutine(int sceneIndex){
			yield return new WaitForSecondsRealtime(delay);
			
			SceneManager.LoadScene(sceneIndex);
		}
		
		IEnumerator QuitRoutine(){
			yield return new WaitForSecondsRealtime(delay);
			
			Application.Quit();
		}
	
	#endregion
}