using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingPanel : BasePanel<SettingPanel>
{
    public CustomGUISlider sliderMusic;
    public CustomGUISlider sliderSound;
    public CustomGUIToggle togMusic;
    public CustomGUIToggle togSound;
    public CustomGUIButton btnClose;
    // Start is called before the first frame update 
    void Start()
    {
        //处理音乐的变化
        sliderMusic.changeValue += (value) => GameDataMgr.Instance.ChangeBGValue(value);
        //处理音效的变化
        sliderSound.changeValue += (value) => GameDataMgr.Instance.ChangeSoundValue(value);
        //处理音乐的开关
        togMusic.changeValue += (value) => GameDataMgr.Instance.OpenOrCloseMusic(value);
        //处理音效的开关
        togSound.changeValue += (value) => GameDataMgr.Instance.OpenOrCloseSound(value);
        
        btnClose.clickEvent += () =>
        {
            HideMe();
            //判断当前场景
            if (SceneManager.GetActiveScene().name== "BeginPanel")
            {
                BeginPanel.Instance.ShowMe();
            }
            BeginPanel.Instance.ShowMe();
        };

        HideMe();
    }

    public void UpdatePanelInfo()
    {
        //面板的数据根据数据库储存的进行更新
        MusicData data = GameDataMgr.Instance.musicData;
        //更新面板数据
        sliderMusic.nowValue = data.bKMusic;
        sliderSound.nowValue = data.soundValue;
        togMusic.isSel = data.isOpenMusic;
        togSound.isSel = data.isOpenSound;

    }

    public override void ShowMe()
    {
        base.ShowMe();
        UpdatePanelInfo();
    }

    public override void HideMe()
    {
        base.HideMe();
        Time.timeScale = 1;
    }
}
