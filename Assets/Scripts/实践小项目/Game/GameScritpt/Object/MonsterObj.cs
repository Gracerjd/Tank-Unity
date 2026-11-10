using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterObj : TankBaseObj
{
    //1.要让坦克来回移动 来回移动的点
    private Transform targetPos;
    //随机用的点，外面去关联
    public Transform[] randomPos;
    //2.坦克要一直盯着自己的目标
    public Transform lookAtTarget;
    //3.当目标达到一定范围后 间隔一段时间 攻击一下目标
    public float fireDis = 5;
    public float fireOffTime = 1;
    private float nowTime = 0;

    public Transform[] shootPos;
    public GameObject bulletObj;

    public Texture maxHpBK;
    public Texture hpBK;
    //之所以不new，是因为结构体，可以直接在下面赋值，而类不行
    private Rect maxHpRect;
    private Rect hpRect;

    private float showTime ;
    // Start is called before the first frame update
    void Start()
    {
        RandomPos();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(targetPos);
        this.transform.Translate(Vector3.forward * movespeed * Time.deltaTime);
        if (Vector3.Distance(this.transform.position,targetPos.position)<0.05f)
        {
            RandomPos();
        }
        if (lookAtTarget!=null)
        {
            tankHead.LookAt(lookAtTarget);
            if (Vector3.Distance(this.transform.position,lookAtTarget.position)<fireDis)
            {
                nowTime += Time.deltaTime;
                if (nowTime>fireOffTime)
                {
                    Fire();
                    nowTime = 0;
                }
            }
        }
    }

    private void RandomPos()
    {
        if (randomPos.Length == 0)
            return;
        targetPos = randomPos[Random.Range(0, randomPos.Length)];
    }

    public override void Fire()
    {
        for (int i = 0; i < shootPos.Length; i++)
        {
            GameObject obj = Instantiate(bulletObj, shootPos[i].position, shootPos[i].rotation);
            //设置子弹的拥有者 之后用于伤害计算
            BulletObj bullet = obj.GetComponent<BulletObj>();
            bullet.SetFather(this);
        }
    }
    public override void Dead()
    {
        base.Dead();
        GamePanel.Instance.AddScore(10);
    }
    /// <summary>
    /// 血条GUI绘制
    /// </summary>
    public void OnGUI()
    {
        if (showTime>0)
        {
            showTime -= Time.deltaTime;

            //1.怪物当前世界坐标转屏幕坐标
            Vector3 screenPos = Camera.main.WorldToScreenPoint(this.transform.position);
            //2.屏幕坐标转GUI坐标
            screenPos.y = Screen.height - screenPos.y;
            //绘制血条图片
            //底图
            maxHpRect.x = screenPos.x - 50;
            maxHpRect.y = screenPos.y - 50;
            maxHpRect.width = 100;
            maxHpRect.height = 10;
            GUI.DrawTexture(maxHpRect, maxHpBK);

            hpRect.x = screenPos.x - 50;
            hpRect.y = screenPos.y - 50;
            hpRect.width = (float)hp / maxHP * 100;
            hpRect.height = 10;
            GUI.DrawTexture(hpRect, hpBK);
        }
        
    }

    public override void Wound(TankBaseObj other)
    {
        base.Wound(other);
        showTime = 3;
    }
}
