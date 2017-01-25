using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    // Audio sources
    public AudioSource SfxAudioSource;
    public AudioSource MusicAudioSource;

    // Music
    public AudioClip MusicMenu;
    public AudioClip MusicInGame;

    // Audio Clips
    public AudioClip AudioClick1;
    public AudioClip AudioClick2;

    public AudioClip JumpClip;
    public AudioClip CoinCollect;

    public static AudioManager Instance;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            DestroyImmediate(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
        PlayMusicMenu();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) == true) {
            int randomElementId = Random.Range(0, 2);
            if (randomElementId == 0) {
                SfxAudioSource.clip = AudioClick1;
            } else {
                SfxAudioSource.clip = AudioClick2;
            }
            // Click Sound
            SfxAudioSource.Play();

        }
    }

    #region API

    public void PlayMusicMenu() {
        MusicAudioSource.clip = MusicMenu;
        MusicAudioSource.Play();
    }

    public void PlayCoinCollect() {
        if (SfxAudioSource.isPlaying == true) {
            SfxAudioSource.Stop();
        }
        SfxAudioSource.clip = CoinCollect;
        SfxAudioSource.Play();
    }

    public void PlayJump() {
        SfxAudioSource.clip = JumpClip;
        SfxAudioSource.Play();
    }

    #endregion
}
