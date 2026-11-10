using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
/// <summary>
/// 小地图跟随代码
/// </summary>
public class CameraMove : MonoBehaviour
{
    public Transform targetPlayer;
    public int H;
    private Vector3 pos;
    
    void LateUpdate()
    {
        if (targetPlayer == null)
            return;
        pos.x = targetPlayer.position.x;
        pos.z = targetPlayer.position.z;
        pos.y = H;
        //把更新的pos位置赋值给这个脚本挂载的对象组件上
        this.transform.position = pos;
    }
}
