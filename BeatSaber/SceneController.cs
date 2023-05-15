using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void  GotoPlayMusicScene()
    {
        PlayerPrefs.SetInt("SceneIndex", 1);
        SceneManager.LoadScene("PlayMusicScene");
        Debug.Log("=> Info: GotoPlayMusicScene() ");
    }
    
    public void GotoMenuScene()
    {
        SceneManager.LoadScene("MenuScene");
        Debug.Log("=> Info: GotoMenuScene() ");
    }
    
    public void Exit()
    {
        UnityEngine.Application.Quit();
        Debug.Log("=> Info: Exit the game() ");
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
