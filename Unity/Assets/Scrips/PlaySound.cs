using UnityEngine;
using System.Collections;

public class PlaySound : MonoBehaviour
{
    public AudioClip[] clip;
	public AudioManager audioManager;


	void Start()
	{
		audioManager = GameObject.FindGameObjectWithTag ("AudioManager").GetComponent<AudioManager> ();
	}
    // Use this for initialization

    public void Play(int num, float volume, float pitch, bool loop)
    {
		audioManager.PlayFX (this.gameObject, clip [num], volume, pitch);
    }
}
