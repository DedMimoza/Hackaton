using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class CatSceneManager : MonoBehaviour
{
    public int num;
    private VideoPlayer vp;

    private void Awake()
    {
        vp = GetComponent<VideoPlayer>();
    }

    void OnEnable() 
    {
        vp.loopPointReached += OnVideoEnd;
    }

    void OnDisable() 
    {
        vp.loopPointReached -= OnVideoEnd;
    }

    void OnVideoEnd(UnityEngine.Video.VideoPlayer causedVideoPlayer)
    {
        SceneManager.LoadScene(num);
    }
}
