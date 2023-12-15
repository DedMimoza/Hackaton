using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundActivator : MonoBehaviour
{
    [SerializeField]AudioClip[] sounds = new AudioClip[2];
    AudioSource sounder;
    AudioClip RealTimeClip;
    // Start is called before the first frame update
    void Start()
    {
        sounder = GetComponent<AudioSource>();
        RealTimeClip = sounder.clip;
    }

    // Update is called once per frame
    void Update()
    {
        if(!sounder.isPlaying)
        {
            sounder.Play();
        }

    }
    public void SwapSound(bool isDanger)
    {     
        if (isDanger)
        {
            sounder.clip = sounds[1];
            print($"Suka изменил {isDanger}");
        }
        else
        {
            sounder.clip = sounds[0];
            print($"Suka изменил {isDanger}");
        }
    }
}
