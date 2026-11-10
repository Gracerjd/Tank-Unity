using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TankBaseObj : MonoBehaviour
{
    public int atk;
    public int def;
    public int maxHP;
    public int hp;

    public float movespeed = 10;
    public float roundspeed = 100;
    public float headroundspeed = 100;

    public GameObject deadeff;
    public Transform tankHead;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public abstract void Fire();
    /// <summary>
    /// 受伤方法，被别人攻击
    /// </summary>
    public virtual void Wound(TankBaseObj other)
    {
        int dmg = other.atk - this.def;
        if (dmg <= 0)
            return;
        this.hp -= dmg;
        if (this.hp<0)
        {
            this.hp = 0;
            Dead();
        }
    }

    public virtual void Dead()
    {
        Destroy(this.gameObject);
        if (deadeff!=null)
        {
            //实例化特效，随便设置位置和角度
            GameObject effobj = Instantiate(deadeff, this.transform.position, this.transform.rotation);
            //特效上关联了音效，在此设置音效
            AudioSource audiosoure = effobj.GetComponent<AudioSource>();
            //设置音效大小
            audiosoure.volume = GameDataMgr.Instance.musicData.soundValue;
            //设置音效开关，用静音
            audiosoure.mute = !GameDataMgr.Instance.musicData.isOpenSound;
        }
    }
}
