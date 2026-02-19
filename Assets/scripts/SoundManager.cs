using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class SoundManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static SoundManager instance;
    [SerializeField] private AudioSource SFXAudioSource;
    [SerializeField] private AudioSource MusikAudioSource;
    [SerializeField] private AudioClip BotHitSound;
    [SerializeField] private AudioClip RobotDestroy;
    [SerializeField] private AudioClip RobotRambling;
    [SerializeField] private AudioClip RobotHover;
    [SerializeField] private AudioClip PlayerWalkSound;
    [SerializeField] private AudioClip PlayerHurtSound;
    [SerializeField] private AudioClip PlayerGrabSound;
    [SerializeField] private AudioClip WaveStartSound;
    [SerializeField] private AudioClip ScoreSound;
    [SerializeField] private AudioClip FehlerSound;
    [SerializeField] private AudioClip LevelMusik;

    private AudioSource a;
    private float masterVol = 1f;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        instance.PlayWaveStartSound();
        instance.PlayLevelMusik();
    }
    public void PlayClipOnSource(AudioSource source, AudioClip clip, float volume = 1f, bool loop = false)
    {
        if (source == null || clip == null) return;

        source.clip = clip;
        source.volume = volume;
        source.loop = loop;
        source.spatialBlend = 1f; 
        source.Play();
    }

  

    public void StartRobotRambling(AudioSource LocalAudioSource)
    {
        PlayClipOnSource(LocalAudioSource, RobotRambling, 0.8f, true);
    }


    public void StartRobotMove(AudioSource LocalAudioSource)
    {
        PlayClipOnSource(LocalAudioSource, RobotHover, 0.8f, true);
    }

    public void PlayRobotDestroy(AudioSource LocalAudioSource)
    {
        PlayClipOnSource(LocalAudioSource, RobotDestroy, masterVol);
    }

    public void PlayPlayerHurtSound()
    {
        SFXAudioSource.PlayOneShot(PlayerHurtSound, masterVol);
    }

    public void PlayWaveStartSound()
    {
        SFXAudioSource.PlayOneShot(WaveStartSound,masterVol);
    }

    public void PlayScoreSound()
    {
        SFXAudioSource.PlayOneShot(ScoreSound,masterVol);
    }

    public void PlayFehlerSound()
    {
        SFXAudioSource.PlayOneShot(FehlerSound, masterVol);
    }

    public void PlayLevelMusik()
    {
        MusikAudioSource.clip = LevelMusik;
        MusikAudioSource.volume = masterVol;
        MusikAudioSource.PlayDelayed(WaveStartSound.length);
    }






    public void PlayBotHitSound()
    {
        a.PlayOneShot(BotHitSound, 1f);
    }

    

}
