using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource musicAudioSource;
    public AudioSource vfxAudioSource;
    public AudioClip soundStrack;
    private bool isPaused = false;


    void Start()
    {
        musicAudioSource.clip = soundStrack;
        musicAudioSource.loop = true;
        musicAudioSource.Play();
    }

    private void Update()
    {

    }
    public void off_music()
    {
        if (!isPaused)
        {
            isPaused = true;
            musicAudioSource.Pause();
        }

    }
    public void on_music()
    {
        if (isPaused)
        {
            isPaused = false;
            musicAudioSource.Play();
        }

    }

}
