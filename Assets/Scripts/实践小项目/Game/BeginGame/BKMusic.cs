using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BKMusic : MonoBehaviour
{
    private static BKMusic instance;
    private AudioSource audiosource;
    public static BKMusic Instance => instance;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        audiosource = this.transform.GetComponent<AudioSource>();
        //初始化 背景音乐的数值为GDM保存的值
        Instance.ChangeValue(GameDataMgr.Instance.musicData.bKMusic);
        Instance.ChangeOpen(GameDataMgr.Instance.musicData.isOpenMusic);
    }

    // Update is called once per frame
    public void ChangeValue(float value)
    {
        audiosource.volume = value;
    }

    public void ChangeOpen(bool isOpen)
    {
        audiosource.mute = !isOpen;
    }
}
