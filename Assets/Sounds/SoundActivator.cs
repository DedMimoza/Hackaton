using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundActivator : MonoBehaviour
{
    public AudioClip[] sounds = new AudioClip[2];
    AudioSource music;
    // Start is called before the first frame update
    void Start()
    {
        music = GetComponent<AudioSource>();
        music.clip = sounds[1];
        music.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!music.isPlaying) music.Play();
    }
    public void SwapMusic(bool isDanger)
    {
        if (isDanger) music.clip = sounds[0];
        else music.clip = sounds[1];
    }
}
