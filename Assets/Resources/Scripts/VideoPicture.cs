using System;
using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
public class VideoPicture : MonoBehaviour
{
    private VideoPlayer _videoPlayer;

    void Start()
    {
        _videoPlayer = GetComponent<VideoPlayer>();
        _videoPlayer.time = 60;
        _videoPlayer.timeReference = VideoTimeReference.InternalTime;
        _videoPlayer.Prepare();
        _videoPlayer.prepareCompleted += OnVideoPlayerPrepared;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<Player>())
        {
            _videoPlayer.Play();
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.GetComponent<Player>())
        {
            _videoPlayer.Pause();
            Debug.Log(_videoPlayer.time);
        }
    }

    private void OnVideoPlayerPrepared(object s)
    {
        _videoPlayer.Play();
        _videoPlayer.Pause();
        _videoPlayer.prepareCompleted -= OnVideoPlayerPrepared;
    }
}
