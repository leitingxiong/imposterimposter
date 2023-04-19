using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenCan : MonoBehaviour
{
    public RoleEntity roleEntity;
    [Header("氧气瓶值")]
    public float oxygenCan = 30;
    public void OnTriggerEnter2D(Collider2D role)
    {
        if (role.TryGetComponent(out roleEntity))
        {
            roleEntity.oxygen += oxygenCan;
            roleEntity.roleAudioSource.clip = roleEntity.roleMusic[7];
            roleEntity.roleAudioSource.Play();
            roleEntity.roleStatus.Set_PropInteraction();
            Destroy(gameObject);
        }
    }
}
