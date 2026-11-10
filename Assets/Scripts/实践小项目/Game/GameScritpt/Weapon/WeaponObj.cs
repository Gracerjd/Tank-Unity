using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponObj : MonoBehaviour
{
    public GameObject bullet;
    //用数组记录发射子弹的位置
    public Transform[] shootPos;

    //记录父类，传递给子弹组件的信息
    public TankBaseObj fatherObj;
    public void SetFather(TankBaseObj Obj)
    {
        fatherObj = Obj;
    }
    public void Fire()
    {
        //遍历数组位置，创建子弹实例
        for (int i = 0; i < shootPos.Length; i++)
        {
            GameObject obj = Instantiate(bullet, shootPos[i].position, shootPos[i].rotation);
            //控制场景创建的子弹做什么
            BulletObj bulletObj = obj.GetComponent<BulletObj>();
            bulletObj.SetFather(fatherObj);
        }
        
    }
}
