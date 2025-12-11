using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
 public static SoundManager instance;

    [SerializeField] private AudioMixerGroup soundFXGroup;

    private AudioSource a;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        a = gameObject.AddComponent<AudioSource>();
        a.outputAudioMixerGroup = soundFXGroup;
    }

    public void PlaySoundClip(AudioClip audioClip)
    {
        a.PlayOneShot(audioClip);
    }
}
