using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosterTower : TankBaseObj
{
    //自动旋转（已挂载）
    //间隔开火时间
    public float fireoffsetTime = 1;
    //发射位置
    public Transform[] shootPos;
    //子弹的预设体
    public GameObject bulletObj;
    private float nowTime;
    public override void Fire()
    {
        for (int i = 0; i < shootPos.Length; i++)
        {
            GameObject obj = Instantiate(bulletObj, shootPos[i].position, shootPos[i].rotation);
            BulletObj bullet = obj.GetComponent<BulletObj>();
            bullet.SetFather(this);
        }
    }
    private void Update()
    {
        nowTime += Time.deltaTime;
        if (nowTime >= fireoffsetTime)
        {
            Fire();
            nowTime = 0;
        }

    }

    public override void Wound(TankBaseObj other)
    {
        //此处不写逻辑，让炮台不会受伤
    }
}
