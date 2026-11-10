using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitPanel : BasePanel<QuitPanel>
{
    public CustomGUIButton btnClose;
    public CustomGUIButton btnQuit;
    public CustomGUIButton btnGoOn;
    // Start is called before the first frame update
    void Start()
    {
        btnClose.clickEvent += () =>
        {
            //关闭界面按钮
            HideMe();
        };
        btnQuit.clickEvent += () =>
        {
            //返回主界面按钮
            SceneManager.LoadScene("BeginScene");

        };
        btnGoOn.clickEvent += () =>
        {
            //关闭界面按钮
            HideMe();
        };
        HideMe();
    }
    public override void HideMe()
    {
        base.HideMe();
        Time.timeScale = 1;
    }

}
