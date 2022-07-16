using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundUpdateEvent
{
    public int targetAudioSource;
    public int targetAudioClip;

    public SoundUpdateEvent(int _source, int _clip)
    {
        targetAudioSource = _source;
        targetAudioClip = _clip;
    }
}

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioClip[] bgm_clips;
    public AudioClip[] sfx_clips;
    public AudioSource[] audioSource;

    void Start()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(this.gameObject);

        PlayBGM(0); // start with main bgm
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
     // placeholder
    }
   
    // play the corresponding bgm
    public void PlayBGM(int clipIdx)
    {
        audioSource[0].clip = bgm_clips[clipIdx];
        audioSource[0].loop = true;
        audioSource[0].Play();
    }
    
    // Play the plane takeoff sfx
    public void PlayPlane()
    {
        audioSource[1].PlayOneShot(sfx_clips[0]);
    }

    // Play the ordinary click sfx
    public void PlayClick()
    {
        audioSource[1].PlayOneShot(sfx_clips[0]);
    }

    // Play the dice rolling sfx
    public void PlayRoll()
    {
        audioSource[1].PlayOneShot(sfx_clips[0]);
    }
}
