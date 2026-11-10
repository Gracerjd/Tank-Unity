using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginPanel : BasePanel<BeginPanel>
{
    public CustomGUIButton btnBegin;
    public CustomGUIButton btnSetting;
    public CustomGUIButton btnQuit;
    public CustomGUIButton btnRank;
    // Start is called before the first frame update
    void Start()
    {
        //锁定鼠标不出屏幕
        Cursor.lockState = CursorLockMode.Confined;

        btnBegin.clickEvent += () =>
        {
            SceneManager.LoadScene("GameScene");
        };
        btnSetting.clickEvent += () =>
        {
            //打开设置面板
            SettingPanel.Instance.ShowMe();
            HideMe();
        };
        btnQuit.clickEvent += () =>
        {
            //退出游戏
            Application.Quit();
        };
        btnRank.clickEvent += () =>
        {
            //打开排行榜面板
            RankPanel.Instance.ShowMe();
            //避免穿透 隐藏自己
            HideMe();
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
