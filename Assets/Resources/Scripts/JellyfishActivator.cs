using UnityEngine;
using UnityEngine.Video;

public class JellyfishActivator : MonoBehaviour
{
    //private Animator _animator;
    private VideoPlayer _videoPlayer;

    void Awake()
    {
        //_animator = GetComponent<Animator>();

        _videoPlayer = GetComponent<VideoPlayer>();
        _videoPlayer.time = 60;
        _videoPlayer.timeReference = VideoTimeReference.InternalTime;
        _videoPlayer.Prepare();
        _videoPlayer.prepareCompleted += OnVideoPlayerPrepared;
    }

    void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponentInParent<Player>();
        if (player != null)
        {
            //_animator.SetBool("is_playing", true);
            _videoPlayer.Play();
        }
    }

    void OnTriggerExit(Collider other)
    {
        var player = other.GetComponentInParent<Player>();
        if (player != null)
        {
            //_animator.SetBool("is_playing", false);
            _videoPlayer.Pause();
        }
    }

    private void OnVideoPlayerPrepared(object s)
    {
        _videoPlayer.Play();
        _videoPlayer.Pause();
        _videoPlayer.prepareCompleted -= OnVideoPlayerPrepared;
    }
}
