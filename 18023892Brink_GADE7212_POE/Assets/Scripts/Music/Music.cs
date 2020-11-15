using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    //links to all music & sound used:
    //--------MUSIC--------
    //November - https://www.bensound.com/royalty-free-music/track/november
    //Tomorrow - https://www.bensound.com/royalty-free-music/track/tomorrow
    //Better Days - https://www.bensound.com/royalty-free-music/track/better-days
    //-------SOUND--------
    //typewriter - https://www.zapsplat.com/music/electronic-typewriter-typing-fast-brother-ax-450-4/
    //button click - https://www.zapsplat.com/music/multimedia-click-1/

    public AudioSource thisMusic;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        thisMusic = GetComponent<AudioSource>();
    }

    public void PlayMusic()
    {
        if (thisMusic.isPlaying) return;
        {
            thisMusic.Play();
        }
    }

    public void StopMusic()
    {
        thisMusic.Stop();
    }
}
