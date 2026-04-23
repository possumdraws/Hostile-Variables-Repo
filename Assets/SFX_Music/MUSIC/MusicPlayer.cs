using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [Header("This will play once when the level loads")]
    public AudioClip INTRO_MUSIC;
    [Header("This will loop after the intro music is finished")]
    public AudioClip LOOP_MUSIC;

    private AudioSource INTRO_SOURCE;
    private AudioSource LOOP_SOURCE;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        INTRO_SOURCE = gameObject.AddComponent<AudioSource>();
        INTRO_SOURCE.clip = INTRO_MUSIC;
        INTRO_SOURCE.loop = false;
        INTRO_SOURCE.Play();

        //schedule loop to play after intro finishes
        float introDuration = INTRO_MUSIC.length;
        LOOP_SOURCE = gameObject.AddComponent<AudioSource>();
        LOOP_SOURCE.clip = LOOP_MUSIC;
        LOOP_SOURCE.loop = true;
        LOOP_SOURCE.PlayScheduled(AudioSettings.dspTime + introDuration);
    }

}
