using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour {

	public static MusicManager instance;

	public AudioClip[] songs;
	int currentSong = 0;

	void Awake(){
		if(instance == null){
			instance = this;
		}

		if(instance != this){
			Destroy(gameObject);
		}
	}

	public void IncreaseTrippy(){
		currentSong = Mathf.Clamp(currentSong + 1, 0, songs.Length-1);
		audio.clip = songs[currentSong];
		audio.Play();
	}

	public void DecreaseTrippy(){
		currentSong = Mathf.Clamp(currentSong - 1, 0, songs.Length-1);
		audio.clip = songs[currentSong];
		audio.Play();
	}

	// Use this for initialization
	void Start () {	
		audio.loop = true;
		audio.clip = songs[currentSong];
		audio.Play();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.B)){
			IncreaseTrippy();
		}
		if(Input.GetKeyUp(KeyCode.N)){
			DecreaseTrippy();
		}
	}
}
