using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(Vimeo.VimeoPlayer))]
public class VideoControl : MonoBehaviour
{
    [Range(0f, 2f)]
    public float playbackSpeed = 1f;

    VideoPlayer player;
    Vimeo.VimeoPlayer vimeoPlayer;

    bool playbackSpeedSet;


    // Use this for initialization
    void Start()
    {
        vimeoPlayer = GetComponent<Vimeo.VimeoPlayer>();
        vimeoPlayer.OnVideoStart += ChangePlaybackSpeed;
    }

    void ChangePlaybackSpeed()
    {
        player = GetComponent<VideoPlayer>();
        player.playbackSpeed = playbackSpeed;
    }

}
