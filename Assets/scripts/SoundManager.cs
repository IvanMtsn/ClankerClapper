using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static SoundManager instance;
    [SerializeField] private AudioSource m_AudioSource;
    [SerializeField] private AudioClip BotHitSound;
    [SerializeField] private AudioClip RobotDestroy;
    [SerializeField] private AudioClip RobotRambling;
    [SerializeField] private float playInterval = 5f;
    private AudioSource a;
    private void Awake()
    {
        if (instance == null)
            instance = this;

        a = GetComponent<AudioSource>();
    }

    public void PlaySoundCLip(AudioClip audioclip, float volume)
    {
        a.PlayOneShot(audioclip, volume);
    }

    public void PlayBotHitSound()
    {
        a.PlayOneShot(BotHitSound, 1f);
    }

    

}
