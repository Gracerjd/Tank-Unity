using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class WinPanel : BasePanel<WinPanel>
{
    public CustomGUIInput inputInfo;
    public CustomGUIButton btnSure;
    // Start is called before the first frame update
    void Start()
    {
        btnSure.clickEvent += () =>
        {
            Time.timeScale = 1;
            GameDataMgr.Instance.AddRankInfo(inputInfo.content.text, GamePanel.Instance.nowscore,
                GamePanel.Instance.nowTime);
            SceneManager.LoadScene("BeginScene");

        };
        HideMe();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
