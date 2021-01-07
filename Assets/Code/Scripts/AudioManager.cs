using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioSource[] soundEffects;
    public AudioSource bgm, levelEndMusic;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        bgm.Play();
    }

    public void PlaySFX(int soundToPlay)
    {
        soundEffects[soundToPlay].Stop();
        soundEffects[soundToPlay].pitch = Random.Range(.9f, 1.1f);
        soundEffects[soundToPlay].Play();
    }

    public void ActivateSFX(int soundToPlay)
    {
        if (soundEffects[soundToPlay].isPlaying == false) 
        {
            soundEffects[soundToPlay].Play();
        }
    }

    public void StopSFX(int soundToPlay)
    {
        soundEffects[soundToPlay].Stop();
    }
}
