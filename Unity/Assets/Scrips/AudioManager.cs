using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class AudioManager : MonoBehaviour 
{
	public AudioMixerGroup fxGroup;

	public void PlayFX(GameObject go, AudioClip clip)
	{
		PlayFX (go, clip, 1, 1);
	}
	public void PlayFX(GameObject go, AudioClip clip, float volume, float pitch)
	{
		AudioSource audioSource = go.AddComponent<AudioSource> ();

		audioSource.outputAudioMixerGroup = fxGroup;

		audioSource.clip = clip;
		audioSource.volume = volume;
		audioSource.pitch = pitch;
		audioSource.clip = clip;
		audioSource.loop = false;
        audioSource.reverbZoneMix = 1;

		audioSource.Play ();

		Destroy (audioSource, clip.length);
	}


}
