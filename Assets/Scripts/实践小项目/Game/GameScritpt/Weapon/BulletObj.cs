using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObj : MonoBehaviour
{
    public float movespeed = 10;
    //记录从武器类获得的父类
    public TankBaseObj fatherObj;
    //武器爆炸特效
    public GameObject eff;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.forward * movespeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube")||
            other.CompareTag("Player")&&fatherObj.CompareTag("Monster")||
            other.CompareTag("Monster")&&fatherObj.CompareTag("Player"))
        {
            //判断是否受伤
            //得到碰撞的对象上 是否有坦克相关的脚本 用里氏替换原则
            //通过父类去获取
            TankBaseObj obj = other.GetComponent<TankBaseObj>();
            if (obj!=null)
            {
                obj.Wound(fatherObj);
            }
            if (eff!=null)
            {
                GameObject effObj = Instantiate(eff, this.transform.position, this.transform.rotation);
                //音效设置
                AudioSource audio1 = effObj.GetComponent<AudioSource>();
                audio1.volume = GameDataMgr.Instance.musicData.soundValue;
                audio1.mute = !GameDataMgr.Instance.musicData.isOpenSound;
            }
            
            Destroy(this.gameObject);

        }
    }
    public void SetFather(TankBaseObj Obj)
    {
        fatherObj = Obj;
    }
}
