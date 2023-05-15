using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataBoardController : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI continue_cnt;
    public TextMeshProUGUI remain_sec;
    public float remain_timer_cur;
    public float remain_timer_prev;

    public void initRemainTimer(int init_remain_sec)
    {
        remain_sec.text = init_remain_sec.ToString();
        remain_timer_cur = init_remain_sec;
        remain_timer_prev = init_remain_sec;
    }
    
    public void score_add()
    {
        score.text = (int.Parse(score.text) + 1).ToString();
    }
    
    public void continue_cnt_add()
    {
        continue_cnt.text = (int.Parse(continue_cnt.text) + 1).ToString();
    }
    
    public void continue_cnt_reset()
    {
        continue_cnt.text = (0).ToString();
    }
    
    public void remain_sec_minus()
    {
        int new_value = (int.Parse(remain_sec.text) - 1);
        if (new_value <= 0)
        {
            GotoMenuScene();
        }
        else
        {
            remain_sec.text = new_value.ToString();
        }
    }

    public void GotoMenuScene()
    {
        SceneManager.LoadScene("MenuScene");
        Debug.Log("=> Info: GotoMenuScene() ");
    }

    private void Update()
    {
        remain_timer_cur -= Time.deltaTime;

        if (remain_timer_prev - remain_timer_cur >= 1)
        {
            remain_sec_minus();
            remain_timer_prev = remain_timer_cur;
        }
    }
}
