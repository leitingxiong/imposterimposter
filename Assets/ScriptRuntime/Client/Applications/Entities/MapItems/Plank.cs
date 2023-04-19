using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Plank : MonoBehaviour
{
    public RoleEntity roleEntity;

    private void OnTriggerEnter2D(Collider2D role)
    {
        if (role.TryGetComponent(out roleEntity))
        {
            roleEntity.HideRole();
            roleEntity.roleStatus.Set_Crouch();
            roleEntity.roleAudioSource.clip = roleEntity.roleMusic[9];
            roleEntity.roleAudioSource.Play();
            Debug.Log(roleEntity);
            Debug.Log("隐藏成功");
        }
    }
    private void OnTriggerExit2D(Collider2D role)
    {
        if (role.TryGetComponent(out roleEntity))
        {
            roleEntity.VisibleRole();
            roleEntity.roleStatus.Unset_Crouch();
        }

    }

}
