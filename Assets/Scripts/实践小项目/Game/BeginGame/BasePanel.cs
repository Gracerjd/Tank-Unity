using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePanel<T> : MonoBehaviour where T:class
{
    //单例模式
    //关键的两个静态成员
    //私有静态成员变量（申明）
    private static T instance;
    //公共的静态成员属性或者方法（获取）
    public static T Instance => instance;
    public void Awake()
    {
        //在生命周期函数Awake中初始化的原因
        //我们的面板脚本在场景上只会挂载一次
        //我们就可以在Awake中直接记录场景上这唯一的脚本
        instance = this as T;
    }

    public virtual void ShowMe()
    {
        this.gameObject.SetActive(true);
    }

    public virtual void HideMe()
    {
        this.gameObject.SetActive(false);
    }
}
