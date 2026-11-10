using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataMgr
{
    //不继承monobehaviour可以直接实例化
    private static GameDataMgr instance = new GameDataMgr();
    public static GameDataMgr Instance { get => instance; }
    //音效数据对象
    public  MusicData musicData;
    //排行榜数据对象
    public RankList rankData;
    private GameDataMgr()
    {
        //去初始化 游戏数据
        musicData = PlayerPrefsDataMgr.Instance.LoadData(typeof(MusicData), "Music") as MusicData;
        
        if (!musicData.notFirst)
        {
            musicData.isOpenMusic = true;
            musicData.isOpenSound = true;
            musicData.bKMusic = 1;
            musicData.soundValue = 1;
            musicData.notFirst = true;
            PlayerPrefsDataMgr.Instance.SaveData(musicData, "Music");
        }
        
        rankData = PlayerPrefsDataMgr.Instance.LoadData(typeof(RankList), "List") as RankList;
    }
    //在排行榜中添加数据的方法
    public void AddRankInfo(string name,int score,float time)
    {
        rankData.list.Add(new RankInfo(name, score, time));
        //排序
        rankData.list.Sort((a, b) => a.time < b.time ? -1 : 1);
        //移除10条以外的数据
        //从尾部往前遍历，移除每一条
        for (int i = rankData.list.Count-1; i >=10; i--)
        {
            rankData.list.RemoveAt(i);
        }
        //另一种写法
        //if (rankData.list.Count>10)
        //{
        //    rankData.list.RemoveRange(10,rankData.list.Count-10);
        //}
        //储存
        PlayerPrefsDataMgr.Instance.SaveData(rankData, "Rank");
    }
    //API：开关音乐
    public void OpenOrCloseMusic(bool isOpen)
    {
        musicData.isOpenMusic = isOpen;

        //控制场景上的背景音乐开关
        BKMusic.Instance.ChangeOpen(isOpen);
        //储存改变后的数据
        PlayerPrefsDataMgr.Instance.SaveData(musicData, "Music");
    }
    //开关音效
    public void OpenOrCloseSound(bool isOpen)
    {
        musicData.isOpenSound = isOpen;
        //储存改变后的数据
        PlayerPrefsDataMgr.Instance.SaveData(musicData, "Music");
    }
    //改变背景音乐大小
    public void ChangeBGValue(float value)
    {
        musicData.bKMusic = value;

        //控制场景上的背景音乐大小
        BKMusic.Instance.ChangeValue(value);
        PlayerPrefsDataMgr.Instance.SaveData(musicData, "Music");
    }
    //改变音效大小
    public void ChangeSoundValue(float value)
    {
        musicData.soundValue = value;
        PlayerPrefsDataMgr.Instance.SaveData(musicData, "Music");
    }
}
