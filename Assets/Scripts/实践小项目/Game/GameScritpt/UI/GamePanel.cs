using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePanel : BasePanel<GamePanel>
{
    public CustomGUILabel LabelScore;
    public CustomGUILabel count;
    public CustomGUIButton btnQuit;
    public CustomGUIButton btnSetting;
    public CustomGUITexture texHP;
    //血条控件的宽
    public float hpw = 245;
    //隐藏面板的特性
    [HideInInspector]
    public int nowscore = 0;
    [HideInInspector]
    public float nowTime = 0;
    private int time;
    // Start is called before the first frame update
    void Start()
    {
        btnSetting.clickEvent += () =>
        {
            //设置面板
            SettingPanel.Instance.ShowMe();
            //改时间缩放值为0，就是时间停止
            Time.timeScale = 0;
        };

        btnQuit.clickEvent += () =>
        {
            //退出界面
            QuitPanel.Instance.ShowMe();
            Time.timeScale = 0;
        };
    }

    // Update is called once per frame
    void Update()
    {
        nowTime += Time.deltaTime;
        //时间换算成整数 秒
        time = (int)nowTime;
        count.content.text = "";
        //换算成时
        if (time/3600>0)
        {
            count.content.text += time / 3600 + "时";
        }
        //换算成分
        if (time%3600/60>0||count.content.text!="")
        {
            count.content.text += time % 3600 / 60 + "分";
        }
        count.content.text += time % 60 + "秒";
    }

    public void AddScore(int score)
    {
        nowscore += score;
        LabelScore.content.text = nowscore.ToString();
    }

    public void UpdateHP(int maxHP, int HP)
    {
        texHP.guiPos.width = (float)HP / maxHP * hpw;
    }
}
