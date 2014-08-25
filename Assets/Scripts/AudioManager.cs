using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

	public AudioClip[] connectionSFX;

	AudioSource source;

	static AudioManager Instance;

	void Awake() {
		source = audio;
		Instance = this;
	}

	public static void playConnectionSFX() {
		Instance.source.PlayOneShot(Instance.connectionSFX[Random.Range(0,Instance.connectionSFX.Length)]);
	}
}
