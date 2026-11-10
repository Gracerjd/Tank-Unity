using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponReward : MonoBehaviour
{
    //存放武器的数组
    public GameObject[] weaponObj;
    //奖励特效
    public GameObject getEff;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //让玩家切换武器 用index索引记录随机数的结果
            int index = Random.Range(0, weaponObj.Length);
            //得到撞到的玩家身上的脚本 再传递到玩家类的切换武器方法
            PlayerObj playerObj = other.GetComponent<PlayerObj>();
            playerObj.ChangeWeapon(weaponObj[index]);

            //播放特效
            GameObject eff = Instantiate(getEff, this.transform.position, this.transform.rotation);
            //控制音效大小
            AudioSource aduios = eff.GetComponent<AudioSource>();
            aduios.volume = GameDataMgr.Instance.musicData.soundValue;
            aduios.mute = !GameDataMgr.Instance.musicData.isOpenSound;

            Destroy(this.gameObject);
        }
    }
}
