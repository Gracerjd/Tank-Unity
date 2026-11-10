using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankPanel : BasePanel<RankPanel>
{
    public CustomGUIButton btnClose;
    private List<CustomGUILabel> labName = new List<CustomGUILabel>();
    private List<CustomGUILabel> labScore = new List<CustomGUILabel>();
    private List<CustomGUILabel> labTime = new List<CustomGUILabel>();
    void Start()
    {
        for (int i = 1; i < 10; i++)
        {
            labName.Add(this.transform.Find("Name/LabelNm" + i).GetComponent<CustomGUILabel>());
            labScore.Add(this.transform.Find("Score/LabelScore" + i).GetComponent<CustomGUILabel>());
            labTime.Add(this.transform.Find("Time/LabelTime" + i).GetComponent<CustomGUILabel>());
        }
        btnClose.clickEvent += () =>
        {
            HideMe();
            BeginPanel.Instance.ShowMe();
        };
        HideMe();
        //测试代码
        //GameDataMgr.Intance.AddRankInfo("杰", 15, 6666);
    }
    public override void ShowMe()
    {
        base.ShowMe();
        UpdatePanelInfo();
    }

    public void UpdatePanelInfo()
    {
        //获取 GameDataMgr中的排行榜列表 用于在这更新
        List<RankInfo> list = GameDataMgr.Instance.rankData.list;
        //根据列表跟新面板数据
        for (int i = 0; i < list.Count; i++)
        {
            labName[i].content.text = list[i].name;
            labScore[i].content.text = list[i].score.ToString();
            int time = (int)list[i].time;
            labTime[i].content.text = "";
            if (time/3600>0)
            {
                labTime[i].content.text += time / 3600 + "时";
            }
            if (time % 3600 / 60 > 0 || labTime[i].content.text!="")
            {
                labTime[i].content.text += time % 3600 / 60 + "分";
            }
            labTime[i].content.text += time % 60 + "秒";
        }
    }
}
