using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Manager : MonoBehaviour
{
    public AudioSource _audioSource;
    public AudioSource _musicSource;
    public AudioClip jumping, collectables, sliding, impact;
    public GameObject lines;
    public void PlaySound(AudioClip type)
    {
        _audioSource.PlayOneShot(type);
    }

    public void StopSound()
    {
        if (_musicSource.isPlaying == true)
        {
            _musicSource.Stop();
            lines.SetActive(false);
        }
        else if (_musicSource.isPlaying == false)
        {
            _musicSource.Play();
            lines.SetActive(true);
        }
        
    }
}
