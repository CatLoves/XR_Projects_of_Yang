using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioSource player; // Background music

    public AudioClip bgm;
    public AudioClip[] SongList;
    public DataBoardController dataBoardController;
    
    // Start is called before the first frame update
    void Start()
    {
        int sceneIndex = PlayerPrefs.GetInt("SceneIndex", 0); 
        int songIndex = PlayerPrefs.GetInt("SongIndex", 0); 
        LogController.LogWarning("=> MusicController start(): sceneIndex= " + sceneIndex + " songIndex= " + songIndex);
        // 一开始就播放背景音乐
        if (sceneIndex == 0)
        {
            player.clip = bgm;
            player.PlayDelayed((float)0.5);
        }
        if (sceneIndex == 1)
        {
            player.clip = SongList[songIndex];
            player.PlayDelayed((float)0.5);
            
            // 初始化数据看板
            int init_remain_sec = 120;
            if (songIndex == 0)
                init_remain_sec = 219;
            if (songIndex == 1)
                init_remain_sec = 258;
            if (songIndex == 2)
                init_remain_sec = 432;
            dataBoardController.initRemainTimer(init_remain_sec);
        }
    }

    public void PlaySelectedMusic(int song_index)
    {
        player.clip = SongList[song_index];
        player.loop = false;
        player.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
