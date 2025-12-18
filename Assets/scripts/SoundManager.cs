using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField] private AudioClip backgroundMusicClip;
    private AudioSource bgmSource;
    private AudioSource a;
    private void Awake()
    {
        if (instance == null)
            instance = this;

        a = GetComponent<AudioSource>();


        bgmSource = gameObject.AddComponent<AudioSource>();
        bgmSource.clip = backgroundMusicClip;
        bgmSource.loop = true;
        bgmSource.playOnAwake = false;
    }

    public void PlayBGM()
    {
        if (!bgmSource.isPlaying)
        {
            bgmSource.Play();
        }
    }

    public void StopBGM()
    {
        if (bgmSource.isPlaying)
        {
            bgmSource.Stop();
        }
    }

    public void PauseBGM()
    {
        if (bgmSource.isPlaying)
        {
            bgmSource.Pause();
        }
    }

    public void ResumeBGM()
    {
        if (!bgmSource.isPlaying)
        {
            bgmSource.UnPause();
        }
    }


}
