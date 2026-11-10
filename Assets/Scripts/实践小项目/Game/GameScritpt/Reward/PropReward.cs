using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_PrpoType
{
    Atk,
    Def,
    MaxHP,
    Hp
}
public class PropReward : MonoBehaviour
{
    public E_PrpoType type = E_PrpoType.Atk;

    public int changeValue = 2;

    public GameObject getEff;
    private void OnTriggerEnter(Collider other)
    {
        //只有玩家才能获得的奖励
        if (other.CompareTag("Player"))
        {
            //获取玩家脚本
            PlayerObj player = other.GetComponent<PlayerObj>();
            switch (type)
            {
                case E_PrpoType.Atk:
                    player.atk += changeValue;
                    break;
                case E_PrpoType.Def:
                    player.def += changeValue;
                    break;
                case E_PrpoType.MaxHP:
                    player.maxHP += changeValue;
                    //更新UI面板
                    GamePanel.Instance.UpdateHP(player.maxHP, player.hp);
                    break;
                case E_PrpoType.Hp:
                    player.hp += changeValue;
                    if (player.hp>player.maxHP)
                    {
                        player.hp = player.maxHP;
                    }
                    //更新UI面板
                    GamePanel.Instance.UpdateHP(player.maxHP, player.hp);
                    break;
                default:
                    break;
            }
        }
        //播放特效
        GameObject eff = Instantiate(getEff, this.transform.position, this.transform.rotation);
        //控制音效大小
        AudioSource audios = eff.GetComponent<AudioSource>();
        audios.volume = GameDataMgr.Instance.musicData.soundValue;
        audios.mute = !GameDataMgr.Instance.musicData.isOpenSound;
        Destroy(this.gameObject);
    }
}
