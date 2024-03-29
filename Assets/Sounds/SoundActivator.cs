using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundActivator : MonoBehaviour
{
    public AudioClip[] sounds = new AudioClip[2];
    AudioSource music;

    public bool isPhone;
    // Start is called before the first frame update
    void Start()
    {
        music = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!music.isPlaying && isPhone) music.Play();

    }
    public void SwapMusic(bool isDanger)
    {
        if (isPhone)
        {
            if (gameObject.name == "SoundManager")
            {
                Debug.Log(music.clip.name);
                if (isDanger && music.clip.name != sounds[0].name)
                {
                    music.clip = sounds[0];
                }
                else if (!isDanger)
                {
                    music.clip = sounds[1];
                }
            }
        }

    }
    public void PlaySoundMove()
    {
        if (!music.isPlaying) music.Play();
    }
    public void StopMusic()
    {
        music.Stop();
    }
}
