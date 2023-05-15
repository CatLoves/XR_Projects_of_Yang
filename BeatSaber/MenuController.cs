using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class MenuController : MonoBehaviour
{
    public XRController leftController;
    public XRController rightController;
    // public Button bt_easy, bt_medium, bt_hard;
    
    public MusicController _musicController;
    // Start is called before the first frame update
    void Awake()
    {
        PlayerPrefs.SetInt("SceneIndex", 0);
        Debug.Log("MenuController awake() is invoked.");
    }

    public void OnButtonMusic1()
    {
        PlayerPrefs.SetInt("SongIndex", 0);
        _musicController.PlaySelectedMusic(song_index:0);
    }
    
    public void OnButtonMusic2()
    {
        PlayerPrefs.SetInt("SongIndex", 1);
        _musicController.PlaySelectedMusic(song_index:1);
    }
    
    public void OnButtonMusic3()
    {
        PlayerPrefs.SetInt("SongIndex", 2);
        _musicController.PlaySelectedMusic(song_index:2);
    }
    
    public void OnButtonMusicMore()
    {
        // 先不管这个
    }
    
    public void OnButtonEasyLevel()
    {
        PlayerPrefs.SetInt("LevelIndex", 0);
        // _musicController.PlayButtonClick();
    }
    
    public void OnButtonMediumLevel()
    {
        PlayerPrefs.SetInt("LevelIndex", 1);
        // _musicController.PlayButtonClick();
    }
    
    public void OnButtonHardLevel()
    {
        PlayerPrefs.SetInt("LevelIndex", 2);
        // _musicController.PlayButtonClick();
    }
    
}
