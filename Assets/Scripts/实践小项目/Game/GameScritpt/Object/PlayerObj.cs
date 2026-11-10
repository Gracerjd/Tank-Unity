using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObj : TankBaseObj
{
    public WeaponObj nowWeapon;

    public Transform weaponPos;

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.Confined;
        //控制玩家前进后退
        this.transform.Translate(Input.GetAxis("Vertical") * Vector3.forward * movespeed * Time.deltaTime);
        //控制玩家旋转朝向
        this.transform.Rotate(Input.GetAxis("Horizontal") * Vector3.up * roundspeed * Time.deltaTime);
        //控制炮台旋转
        tankHead.transform.Rotate(Input.GetAxis("Mouse X")*Vector3.up * headroundspeed * Time.deltaTime);
        //控制开火
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    public override void Fire()
    {
        if (nowWeapon!=null)
        {
            nowWeapon.Fire();
        }
    }
    /// <summary>
    /// 死亡
    /// </summary>
    public override void Dead()
    {
        //不实现父类代码，因为当玩家死亡时，会移除脚本，导致摄像机丢失
        //base.Dead();
        Time.timeScale = 0;
        LosePanel.Instance.ShowMe();
    }
    /// <summary>
    /// 受伤
    /// </summary>
    /// <param name="other"></param>
    public override void Wound(TankBaseObj other)
    {
        base.Wound(other);
        //更新主面板
        GamePanel.Instance.UpdateHP(this.maxHP, this.hp);

    }
    /// <summary>
    /// 切换武器
    /// </summary>
    /// <param name="Weapon"></param>
    public void ChangeWeapon(GameObject Weapon)
    {
        if (nowWeapon!=null)
        {
            Destroy(nowWeapon.gameObject);
            nowWeapon = null;
        }
        //切换武器
        GameObject weaponObj = Instantiate(Weapon, weaponPos, false);
        nowWeapon = weaponObj.GetComponent<WeaponObj>();
        nowWeapon.SetFather(this);

    }
}
