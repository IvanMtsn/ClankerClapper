using UnityEngine;
using UnityEngine.Audio;

public class SoundMixerManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private AudioMixer audioMixer;

    public void SetSoundFXVolume(float level)
    {
        if (level <= 0.0001f)
        {
            audioMixer.SetFloat("MixerSoundFXVolume", -80f);
            return;
        }
        float volumeInDb = Mathf.Log10(level) * 20f;
        audioMixer.SetFloat("MixerSoundFXVolume", volumeInDb);
    }

    public void SetMusikVolume(float level)
    {
        if (level <= 0.0001f)
        {
            audioMixer.SetFloat("MixerMusikVolume", -80f);
            return;
        }

        float volumeInDb = Mathf.Log10(level) * 20f;
        audioMixer.SetFloat("MixerMusikVolume", volumeInDb);
    }
}
