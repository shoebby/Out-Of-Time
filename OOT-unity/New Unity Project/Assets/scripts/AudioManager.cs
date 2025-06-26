using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    public AudioSource src_music;
    public AudioSource src_sfx;

    public void PlayMusic(AudioClip clip)
    {
        src_music.clip = clip;
        src_music.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        src_sfx.PlayOneShot(clip);
    }
}
