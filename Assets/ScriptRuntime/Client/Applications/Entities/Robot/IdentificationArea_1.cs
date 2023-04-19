using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdentificationArea_1 : MonoBehaviour
{
    public RobotEntity robotEntity;

    private RoleEntity roleEntity;

    /// <summary>
    /// 进入可识别攻击区域，则机器人进入攻击模式，这里需要玩家的照明状态接口判定接口
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out roleEntity)&&!roleEntity.isHide)
        {
            robotEntity.EnterAttackingStatus();
        }
    }



}
