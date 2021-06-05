using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
	#region Singleton
	
		public static AudioManager instance{ get; private set; }
		
		void Awake(){
			if(!instance) instance = this;
			else{
				Destroy(gameObject);
				return;
			}
			
			DontDestroyOnLoad(gameObject);
		}
	
	#endregion
	
	[System.Serializable]
	public class Sound{
		
		public string name;
		
		[HideInInspector]
		public AudioSource source;
		public AudioClip clip;
		
		[Range(0,1)] public float volume = 0.5f;
		[Range(0.1f, 3f)] public float pitch = 1f;
		
		public bool loop;
		
		public void Setup(AudioSource newSource){
			this.source = newSource;
			
			source.clip = clip;
			source.volume = volume;
			source.pitch = pitch;
			source.loop = loop;
		}
		
		public void Play(){
			source?.Play();
		}
	}
	
	public Sound[] sounds;
	
	void Start(){
		foreach(var s in sounds)
			s.Setup(gameObject.AddComponent<AudioSource>());
	}
	
	public void Play(string name){
		var sound = Array.Find(sounds, s => s.name == name);
			sound.Play();	
	}
	
	public void Play(int index){
		sounds[index].Play();
	}
}