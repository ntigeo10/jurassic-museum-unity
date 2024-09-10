using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


public class VideoControls : MonoBehaviour
{
    private VideoPlayer video;
    private bool isPlaying = false;

    private void Awake()
    {
        video = GetComponent<VideoPlayer>();
    }

    private void Update()
    {
        if (isPlaying)
        {
            if(Input.GetKeyDown(KeyCode.J))
                pauseVideo();
            if (Input.GetKeyDown(KeyCode.K))
                Forward();
            if (Input.GetKeyDown(KeyCode.H))
                Backwards();

        }            
        else if (!isPlaying )
        {
            if (Input.GetKeyDown(KeyCode.J))
                playVideo();
            if (Input.GetKeyDown(KeyCode.K))
                Forward();
            if (Input.GetKeyDown(KeyCode.H))
                Backwards();
        }
            
    }

    public void playVideo()
    {
        video.Play();
        isPlaying = true;
    }

    public void pauseVideo()
    {
        video.Pause();
        isPlaying = false;
    }

    public void Forward()
    {
        video.time += 1.0f;
    }

    public void Backwards()
    {
        video.time -= 1.0f;
    }
}
