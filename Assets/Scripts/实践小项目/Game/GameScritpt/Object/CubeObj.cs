using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeObj : MonoBehaviour
{
    public GameObject[] rewardObj;

    public GameObject deadEff;
    private void OnTriggerEnter(Collider other)
    {
        //1打到自己的子弹销毁（在BulletObj中已实现）
        //2打到自己随机创建奖励
        //创建一个随机数
        int rangeInt = Random.Range(0, 99);
        if (rangeInt<33)
        {
            //随机创建一个预设体
            rangeInt = Random.Range(0, rewardObj.Length);
            Instantiate(rewardObj[rangeInt], this.transform.position, this.transform.rotation);
        }

        //播放特效
        GameObject eff = Instantiate(deadEff, this.transform.position, this.transform.rotation);
        //控制音效大小
        AudioSource audios = eff.GetComponent<AudioSource>();
        if (audios != null)
        {
            audios.volume = GameDataMgr.Instance.musicData.soundValue;
            audios.mute = !GameDataMgr.Instance.musicData.isOpenSound;
        }
        Destroy(this.gameObject);
       

    }
}
